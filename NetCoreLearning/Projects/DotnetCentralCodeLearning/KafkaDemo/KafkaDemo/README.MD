### Commands to run Kafka 

# Start Zookeeper Server

# Start Kafka Server
`
kafka-server-start.bat ..\..\config\server.properties
`

# Create Topic
 -> **The replication factor controls how many servers will replicate each message that is written.**
`
 -> **The partition count controls how many logs the topic will be sharded into**  
kafka-topics.bat --create --bootstrap-server localhost:9092 --replication-factor 1 --partitions 1 --topic KafkaReceiveMsgDemo
`

# Start Kafka Producer
`
kafka-console-producer.bat --broker-list localhost:9092 --topic KafkaReceiveMsgDemo
`

# Start Kafka Console Comsumer 
`
kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic KafkaReceiveMsgDemo
`