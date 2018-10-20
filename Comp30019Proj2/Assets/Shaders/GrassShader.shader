// Created by Mayank Sharma.
// Basic default unlit shader created for the sole purpose of providing texture to the enemy.
Shader "Unlit/GrassShader"
{
	Properties
	{
		
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			
				fixed4 col = float4(0.0,0.6,0.0,1.0);
			
				return col;
			}
			ENDCG
		}
	}
}
