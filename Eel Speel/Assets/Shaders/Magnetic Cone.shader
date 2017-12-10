Shader "Unlit/Magnetic Cone"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Position("HeadPos", Vector) = (0,0,0,0)
		_Frequency("Frequency", Range(1,100)) = 1
		
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True"}
		Blend SrcAlpha OneMinusSrcAlpha

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
				float distance : TEXCOORD0;
			};

			float4 _Position;
			float4 _Color;
			float _Frequency;
			
			v2f vert (appdata v)
			{
				v2f o;
				float4 d = _Position - mul(unity_ObjectToWorld,v.vertex);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.distance = length(d);
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{

				float l = (i.distance - _Time.g) * _Frequency;
				float mag = sin(l) + 1;
				return _Color * mag;
			}
			ENDCG
		}
	}
}
