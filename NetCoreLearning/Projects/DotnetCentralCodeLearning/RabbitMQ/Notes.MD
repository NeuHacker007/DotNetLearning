### RabbitMq

---
#### Docker Env

docker run --hostname ivan-rabbit --name ivan-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management

#### Type of Exchange

----

**Direct**: Direct exchange uses routing key in the header to identify which queue the message should be sent to. 

---

**Topic**: Topic exchange also uses routing key, but it does not do an exact match on the routing key, instead it does a pattern match based on pattern

---

**Header**: Header exchange routes messages based on header values.

---

**Fanout**: routes messages to all the queueues bound to it.

---


