#version 330 core
in vec2 TexCoord;

in float ExitDistance;
in float ViewDistance;
in vec3 FragPos;
in vec3 LightPos;
in vec3 Normal;

out vec4 color;

uniform sampler2D ourTexture1;
uniform sampler2D ourTexture2;

void main()
{
  vec3 objectColor = texture(ourTexture1, TexCoord).xyz;
  // light color
  vec3 lightColor = vec3(1.0, 1.0, 1.0);
  // distance to light
  float dist = ViewDistance;
  // ambient light calculation
  float ambientStrength = 0.2f;
  vec3 ambient = ambientStrength * lightColor;
  // calculate diffuse lightning
  vec3 norm = normalize(Normal);
  vec3 lightDir = normalize(LightPos - FragPos);
  float diff = max(dot(norm, lightDir), 0.0);
  vec3 diffuse = diff * 0.5 * lightColor;
  // specular
  vec3 viewPos = LightPos;
  vec3 viewDir = normalize(viewPos - FragPos);
  vec3 reflectDir = reflect(-lightDir, norm);
  float specularStrength = 0.5f;
  float spec = pow(max(dot(viewDir, reflectDir), 0.0), 8);
  vec3 specular = specularStrength * spec * lightColor;
  // ligth attenuation
  float radius = 5.0f;
  float att = clamp(1.0 - dist/radius, 0.0, 1.0); att *= att;
  // result of both lights applied
  vec3 result = (ambient + att * (ambient + diffuse + specular)) * objectColor;
  color = vec4(result, 1.0f);
}
