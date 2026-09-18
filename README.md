
# API Reference da Polimédica do Vale

Este é um projeto para a Polimédica do Vale, que vai englobar algumas tasks que precisam ser automatizadas.

## Os serviços serão

- 1º Controle de Roteiro
- 2º Controle de Caixa
- 2º Controle de vendas
- 3º Lista de Compras
- 4º Fechamentos


## Iniciando com Controle de Roteiro
#### Get

O GET vai funcionar de duas formas:

A primeira é o endponit sem valor que retorna a lista de entregas do dia atual.

```http
  GET /polimedica/roteiro
```

| Parameter | Type           | Description                  |
| :-------- | :------------- | :--------------------------- |
|     ``    | `List<Object>` | Retorno de entragas por dia. |

#### Get/data

O GET vai funcionar de duas formas:

A segunda é colocado uma data de referencia e é feito uma pesquisa no BD para retornar todas as entregas daquele dia escolhido.

```http
  GET /polimedica/roteiro/{ano:int}/{mes:int}/{dia:int}
```

| Parameter | Type           | Description                  |
| :-------- | :------------- | :--------------------------- |
|   `Data`  | `List<Object>` | Retorno de entragas no dia escolhido. |


#### Post

```http
  POST /polimedica/roteiro
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Objct`      | `Objct` | `Faz o cadastro de uma nova entrega.` |

#### Put

```http
  PUT /polimedica/roteiro/{int:id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Objct`      | `Objct` | `Atualiza a entrega selecionada.` |

 #### Delete

```http
  DELETE /polimedica/roteiro/{int:id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `Objct`      | `Objct` | `Apaga a entrega selecionada.` |
