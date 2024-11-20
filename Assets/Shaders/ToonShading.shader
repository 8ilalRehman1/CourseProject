Shader "ToonShading"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _RampTex ("Ramp Texture", 2D) = "white" {}
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf ToonRamp
        sampler2D _RampTex;
        fixed4 _Color;
        /** Attenuation is not needed, but
        it is included because it is part
        of the function.
        Set the diffuse lighting to the
        dot product of the source and
        the light direction.
        The diffuse lighting will be the
        brightest where the normal of
        the surface and the lighting
        direction is coming from.
        The h value pulls the values
        from the ramp. **/
        float4 LightingToonRamp (SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            float diff = dot (s.Normal, lightDir);
            float h = diff * 0.5 + 0.5;
            float2 rh = h;
            float ramp = tex2D(_RampTex, rh).rgb;
            float4 c;
            c.rgb = s.Albedo * _LightColor0.rgb * (ramp);
            c.a = s.Alpha;
            return c;
        }

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {
            
            o.Albedo = _Color.rgb;
            
        }
        ENDCG
    }
    FallBack "Diffuse"
}
