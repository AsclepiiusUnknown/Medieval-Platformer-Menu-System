Shader "hidden/Custom Shaders/Wireframe-Transparent-Global"
{
	SubShader
	{
		Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Opaque"
        }

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
			Cull Off

			CGPROGRAM
			#pragma vertex vert
			#pragma geometry geom
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "../Wireframe.cginc"

			ENDCG
		}
	}
}
