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
  vec3 lightColor = vec3(1.0, 0.8, 0.4);
  // distance to light
  float dist = ViewDistance;
  // ambient light calculation
  float ambientStrength = 0.3f;
  vec3 ambient = ambientStrength * lightColor;
  // calculate diffuse lightning
  vec3 norm = normalize(Normal);
  vec3 lightDir = normalize(LightPos - FragPos);
  float diff = max(dot(norm, lightDir), 0.0);
  vec3 diffuse = diff * 0.3 * lightColor;
  // specular
  vec3 viewPos = LightPos;
  vec3 viewDir = normalize(viewPos - FragPos);
  vec3 reflectDir = reflect(-lightDir, norm);
  float specularStrength = 1.0;
  float spec = pow(max(dot(viewDir, reflectDir), 0.0), 8);
  vec3 specular = specularStrength * spec * lightColor;
  // ligth attenuation
  float radius = 5.0f;
  float att = clamp(1.0 - dist/radius, 0.0, 1.0); att *= att;
  // exit portal
  // float eatt = clamp(1.0 - ExitDistance/3.0, 0.0, 1.0); eatt *= eatt;
  // objectColor += (eatt * vec3(1.0, 0.0, 1.0));
  if(ExitDistance < 1.0){
    objectColor += vec3(1.0, 0.0, 1.0);
  }
  // result
  vec3 result = (ambient + att * (ambient + diffuse + specular)) * objectColor;
  color = vec4(result, 1.0f);
}
