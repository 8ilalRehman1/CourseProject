Shader "Lambert"
{
    Properties
    {
        //lambert
        _Color ("Color", Color) = (1.0,1.0,1.0)
    }
    SubShader
    {
        Tags {"Lightmode" = "ForwardBase"}
        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // user defined variables
            uniform float4 _Color;
            // unity defined variables
            uniform float4 _LightColor0;
            // base input structs
            struct vertexInput {
                float4 vertex: POSITION;
                float3 normal: NORMAL;
            };
            struct vertexOutput {
                float4 pos: SV_POSITION;
                float4 col: COLOR;
            };
            // vertex functions
            vertexOutput vert(vertexInput v) {
                vertexOutput o;
                float3 normalDirection = normalize(mul(float4(v.normal,0.0),unity_WorldToObject).xyz);
                float3 lightDirection;
                float atten = 1.0;
                lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 diffuseReflection = atten
                *_LightColor0.xyz*_Color.rgb*max(0.0,dot(normalDirection, lightDirection));
                o.col = float4(diffuseReflection, 1.0);
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            // fragment function
            float4 frag(vertexOutput i) : COLOR
            {
                return i.col;
            }
            ENDCG
        }
    }
}
/** Why do we use world to object matrix?
 V.normal provides the normal vector in model space.
 We need this in world space.
 Therefore, we use unity_WorldToObject matrix to compute the
transformation.
 mul does the matrix multiplication.
 We normalize to get values
between -1 and +1 (i.e., unit
vector).
Provides the light direction in
world space
Light and Normal direction relative
to world space, and the dot product
provides the intensity.
Negative values indicate the angle
between normal and light is higher
than 90 degrees.
To avoid lighting falling on these
vertex positions, a max function is
used.
atten provides the strength of light
that falls on the surface.
Diffuse reflection color is obtained
by multiplying attenuation, color of
the direct light, color of the object,
and dot product of the normal and
light direction.

**/