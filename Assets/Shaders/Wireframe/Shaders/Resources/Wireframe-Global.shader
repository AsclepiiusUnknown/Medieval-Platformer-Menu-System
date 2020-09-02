Shader "hidden/Custom Shaders/Wireframe-Global"
{
	SubShader
	{
		// Each color represents a meter.

		Tags { "RenderType"="Opaque" }

		Pass
		{
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
