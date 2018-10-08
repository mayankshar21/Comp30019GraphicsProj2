Shader "Unlit/CelShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "LightMode"="ForwardBase" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			uniform fixed4 _LightColor0;

			struct vertIn
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : NORMAL;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			vertOut vert (vertIn v)
			{
				vertOut o;

				float3 worldNormal = normalize(mul(transpose((float3x3) unity_WorldToObject), v.normal.xyz));
				
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);

				o.worldNormal = worldNormal;

				return o;
			}
			
			fixed4 frag (vertOut v) : SV_Target
			{
				// setting up constants parameters
				float objectOutline = 0.3;
				float diffusionThreshold = 4.0;

				// setting up the different vector components
				float3 V = normalize(_WorldSpaceCameraPos);
				float3 L = normalize(_WorldSpaceLightPos0);
				float3 interpNormal = normalize(v.worldNormal);

				// dot product of matrices
				float LdotN = dot(L, interpNormal);
				float outLineWidth = saturate((dot(interpNormal, V) - objectOutline) * 1000);
				
				// setting up ambient component of Cel Shader
				float Ka = 0.3;
				float amb = Ka;

				// setting up diffuse component of Cel Shader
				float fAtt = 1;
				float Kd = 1;
				float dif = fAtt * Kd * floor(LdotN * diffusionThreshold) / (diffusionThreshold - 0.5);

				// sample the texture
				fixed4 returnColor = tex2D(_MainTex, v.uv);
				returnColor.rgb = returnColor.rgb * saturate(dif + amb) * _LightColor0.rgb * outLineWidth;
				return returnColor;
			}
			ENDCG
		}
	}
}
