## Инциденты

### Создать инцидент
<details>
   <summary>
      <code>POST incidents</code>
   </summary>

> ### Тело запроса:
> ```json
> {
>   "title": "string",
>   "description": "string",
>   "status": "string",
>   "reporterId": "string",
>   "assigneeId": "string (optional)"
> }
> ```
>
> ### Тело ответа:
> ```json
> {
>   "id": "string",
>   "title": "string",
>   "description": "string",
>   "status": "string",
>   "reporterId": "string",
>   "assigneeId": "string (optional)"
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 201 Created, 400 Bad Request, 401 Unauthorized, 403 Forbidden
</details>

### Просмотреть инциденты
<details>
   <summary>
      <code>GET incidents</code>
   </summary>

>
> ### Тело ответа:
> ```json
> {
>   "incidents": [
>     {
>       "id": "string",
>       "title": "string",
>       "status": "OPEN",
>       "severity": 0.0,
>       "created_at": 1704067200
>     }
>   ]
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 200 Ok, 401 Unauthorized, 403 Forbidden
</details>

### Просмотреть один инцидент
<details>
   <summary>
      <code>GET incidents/{incidentId}</code>
   </summary>

>
> ### Параметры пути:
> `incidentId` (string) – идентификатор инцидента
>
> ### Тело ответа:
> ```json
> {
> "id": "string",
> "title": "string",
> "description": "string",
> "status": "OPEN | RESOLVED | CANCELED | PENDING",
> "severity": 0.0,
> "reporter_id": "string",
> "assignee_id": "string (optional)",
> "unitId": "string",
> "created_at": 1704067200
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 200 Ok, 401 Unauthorized, 403 Forbidden, 404 Not Found
</details>





## Метрики

### Добавить метрику
<details>
   <summary>
      <code>POST metrics</code>
   </summary>

> ### Тело запроса:
> ```json
> {
>   "severity": "string",
>   "title": "string",
>   "description": "string",
>   "query": "string",
>   "threshold": 0.0,
>   "thresholdDirection": "EQUAL | LESS | GREATER",
>   "runbookLinkTemplate": "string (optional)",
>   "monitoringLinkTemplate": "string (optional)"
> }

> ### Тело ответа:
> ```json
> {
>   "id": "string",
>   "severity": "string",
>   "title": "string",
>   "description": "string",
>   "query": "string",
>   "threshold": 0.0,
>   "thresholdDirection": "EQUAL | LESS | GREATER",
>   "runbookLinkTemplate": "string (optional)",
>   "monitoringLinkTemplate": "string (optional)"
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 201 Created, 400 Bad Request, 401 Unauthorized, 403 Forbidden
</details>

### Получить метрики
<details>
   <summary>
      <code>GET metrics</code>
   </summary>

>
> ### Query – параметры:
> `name` (string, optional) – фильтрация по имени метрики
>
> ### Тело ответа:
> ```json
> {
>   "metrics": [
>     {
>       "id": "string",
>       "severity": "string",
>       "title": "string",
>       "description": "string",
>       "query": "string",
>       "threshold": 0.0,
>       "thresholdDirection": "EQUAL | LESS | GREATER",
>       "runbookLinkTemplate": "string (optional)",
>       "monitoringLinkTemplate": "string (optional)"
>     }
>   ]
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 200 Ok, 401 Unauthorized, 403 Forbidden
</details>

### Получить одну метрику
<details>
   <summary>
      <code>GET metrics/{metricId}</code>
   </summary>

> ### Параметры пути:
> `metricId` (string) – идентификатор метрики
>
> ### Тело ответа:
> ```json
> {
>   "id": "string",
>   "severity": "string",
>   "title": "string",
>   "description": "string",
>   "query": "string",
>   "threshold": 0.0,
>   "thresholdDirection": "EQUAL | LESS | GREATER",
>   "runbookLinkTemplate": "string (optional)",
>   "monitoringLinkTemplate": "string (optional)"
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 200 Ok, 401 Unauthorized, 403 Forbidden, 404 Not Found
</details>





## Юниты

### Добавить юнит
<details>
   <summary>
      <code>POST units</code>
   </summary>

> ### Тело запроса:
> ```json
> {
>   "name": "string",
>   "description": "string",
>   "severity": 0.0,
>   "type": "string",
>   "parentId": "string (optional)"
> }
> ```
>
> ### Тело ответа:
> ```json
> {
>   "id": "string",
>   "name": "string",
>   "severity": 0.0,
>   "type": "string",
>   "subUnitsIds": [],
>   "teams": []
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 201 Created, 400 Bad Request, 401 Unauthorized, 403 Forbidden
</details>



### Получить юнит
<details>
   <summary>
      <code>GET units/{id}</code>
   </summary>

>
> ### Параметры пути:
> `id` (string) – идентификатор юнита
>
> ### Тело ответа:
> ```json
> {
>   "id": "string",
>   "name": "string",
>   "severity": 0.0,
>   "type": "string",
>   "subUnitsIds": ["string"],
>   "teams": [
>     {
>       "id": "string",
>       "name": "string"
>     }
>   ]
> }
> ```
> #### Ожидаемые возвращаемые статус-коды: 200 Ok, 401 Unauthorized, 403 Forbidden, 404 Not Found
</details>

### Удалить юнит
<details>
   <summary>
      <code>DELETE units/{id}</code>
   </summary>

>
> ### Параметры пути:
> `id` (string) – идентификатор юнита
>
> ### Тело ответа:
> Отсутствует
>
> #### Ожидаемые возвращаемые статус-коды: 204 No Content, 401 Unauthorized, 403 Forbidden, 404 Not Found
</details>