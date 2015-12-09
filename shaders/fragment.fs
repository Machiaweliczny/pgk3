#version 330 core
in vec2 TexCoord;
in float ViewDistance;
in float ExitDistance;

out vec4 color;

uniform sampler2D ourTexture1;
uniform sampler2D ourTexture2;

void main()
{
  color = texture(ourTexture1, TexCoord);
	float ambientStrength = 0.1;
  color *= ambientStrength + vec4(1.0,0.0,1.0,1.0)/(ExitDistance*ExitDistance*3)
    +  vec4(1.0,1.0,1.0,1.0)/(ViewDistance*ViewDistance);
	color[3] = 1.0;
}
