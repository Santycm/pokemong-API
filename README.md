**FORMATO JSON**
### Para agregar un solo pokemon con valores de habilidades aleatorios
```
{
  "id":1,
  "name":"Steelix",
  "type":"Acero"
}

```

### Para agregar multiples pokemones con valores de habilidades aleatorios
```
[{
  "id":1,
  "name":"Kingler",
  "type":"Agua"
},
{
  "id":2,
  "name":"Blastoise",
  "type":"Agua"
},
{
  "id":3,
  "name":"Steelix",
  "type":"Acero"
}]
```
### Para agregar un solo pokemon con valores de habilidades predifinidos
```
{
  "id":1,
  "name":"Steelix",
  "type":"Acero",
  "skills":[
    {
      "id":"POW68AND1",
      "attack1": 28,
      "attack2": 25,
      "attack3": 13,
      "attack4": 7,
      "defense": 16.39
    }
    ]
}
```

### Para agregar multiples pokemones con valores de habilidades predefinidos
```
[{
  "id":1,
  "name":"Kingler",
  "type":"Agua",
  "skills":[
    {
      "id":"POW68AND41",
      "attack1": 28,
      "attack2": 25,
      "attack3": 13,
      "attack4": 7,
      "defense": 16.39
    }
    ]
},
{
  "id":2,
  "name":"Blastoise",
  "type":"Agua",
  "skills":[
    {
      "id":"POW68AND10",
      "attack1": 28,
      "attack2": 25,
      "attack3": 13,
      "attack4": 7,
      "defense": 16.39
    }
    ]
},
{
  "id":3,
  "name":"Steelix",
  "type":"Acero",
  "skills":[
    {
      "id":"POW68AND4",
      "attack1": 28,
      "attack2": 25,
      "attack3": 13,
      "attack4": 7,
      "defense": 16.39
    }
    ]
}]
```

### Para editar un Pokemon (PUT:Solo se permite actuallizar el nombre y tipo)
```
{
  "id":1,
  "name":"Steelix",
  "type":"Acero"
}
```

### Para editar parcialmente un Pokemon (PATCH: Solo se permite actuallizar el nombre y tipo)
```
{
  "type":"Aceroo"
}
```

**COMANDS FOR INIT WEB API**
```
dotnet new web
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.17
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 7.0.17
```
