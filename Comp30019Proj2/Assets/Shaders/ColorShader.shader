Shader "Unlit/ColorShader"
{
	Properties
	{
		_Color("Color", color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct vertIn
			{
				float4 vertex : POSITION;
				float4 color : COLOR;
			};

			struct vertOut
			{
				float4 color : COLOR;
				float4 vertex : SV_POSITION;
			};
			
			vertOut vert (vertIn v)
			{
				vertOut o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				return o;
			}

			half4 _Color;
			
			fixed4 frag (vertOut v) : SV_Target
			{
				fixed4 returnColor = float4(1,1,0,1) * _Color;
				return returnColor;
			}
			ENDCG
		}
	}
}
