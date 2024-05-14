**FORMATO JSON**
_Para agregar un solo pokemon con valores de habilidades aleatorios_
`{
  "id":1,
  "name":"Steelix",
  "type":"Acero"
}`

_Para agregar multiples pokemones con valores de habilidades aleatorios_
`[{
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
}]`
_Para agregar un solo pokemon con valores de habilidades predifinidos_
`{
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
}`

_Para agregar multiples pokemones con valores de habilidades predefinidos_
`[{
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
}]`

_Para editar un Pokemon (PUT:Solo se permite actuallizar el nombre y tipo)_
`{
  "id":1,
  "name":"Steelix",
  "type":"Acero"
}`

_Para editar parcialmente un Pokemon (PATCH: Solo se permite actuallizar el nombre y tipo)_
`{
  "type":"Aceroo"
}`
