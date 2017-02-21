Shader "Masked/DepthFirst" {

	SubShader{
		// Render the mask after regular geometry, but before masked geometry and
		// transparent things.

		Tags{ "Queue" = "Geometry+10" }

		// Don't draw in the RGBA channels; just the depth buffer

		ColorMask 0
		ZWrite On
		ZTest off

		// Do nothing specific in the pass:

		Pass{}
	}
}