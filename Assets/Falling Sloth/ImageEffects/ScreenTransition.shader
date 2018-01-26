Shader "Hidden/ScreenTransition"
{
	Properties
	{
		_MainTex ("Screen texture", 2D) = "white" {}
		_TransitionGradient ("Transition gradient", 2D) = "white" {}
		_Cutoff ("Cut off", Range(0.0, 1.0)) = 0.0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _TransitionGradient;
			float _Cutoff;

			const fixed4 _black = fixed4(0.0, 0.0, 0.0, 1.1);

			fixed4 frag (v2f i) : SV_Target
			{
				// fixed4 col = tex2D(_MainTex, i.uv);
				
				if (_Cutoff == 1.0 && tex2D(_TransitionGradient, i.uv).b == 1.0)
					return _black;
				else if (tex2D(_TransitionGradient, i.uv).b < _Cutoff)
					return _black;
				else
					return tex2D(_MainTex, i.uv);
			}
			ENDCG
		}
	}
}
