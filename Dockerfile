FROM rabbitmq:3.7.7-management
RUN rabbitmq-plugins enable rabbitmq_shovel
