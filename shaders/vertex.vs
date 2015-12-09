#version 330 core
layout (location = 0) in vec3 position;
layout (location = 1) in vec3 normal;
layout (location = 2) in vec2 texCoord;

out vec2 TexCoord;

out vec3 Normal;
out vec3 FragPos;
out float ExitDistance;
out float ViewDistance;
out vec3 LightPos;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform vec3 exit;

void main()
{
	vec3 cameraPosition = -view[3].xyz * mat3(view);
	LightPos = cameraPosition;
	vec3 worldPosition =  (model * vec4(position, 1.0f)).xyz;
	FragPos = worldPosition;
	ViewDistance = length(worldPosition - cameraPosition);
	ExitDistance = length(worldPosition - exit);
	Normal = normal;

  gl_Position = projection * view * model * vec4(position, 1.0f);
  TexCoord = vec2(texCoord.x, 1.0 - texCoord.y);
}
