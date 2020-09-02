Shader "hidden/Custom Shaders/Wireframe-Transparent-Culled-Global"
{
	SubShader
	{
		// Each color represents a meter.

		Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Opaque"
        }

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
			Cull Back

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
