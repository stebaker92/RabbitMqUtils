FROM rabbitmq:3.7.7-management

RUN apt-get update

RUN apt-get install zip -y

WORKDIR /usr/lib/rabbitmq/lib/rabbitmq_server-3.7.7/plugins/

ADD https://dl.bintray.com/rabbitmq/community-plugins/3.7.x/rabbitmq_message_timestamp/rabbitmq_message_timestamp-20170830-3.7.x.zip .

RUN apt-get install unzip && unzip rabbitmq_message_timestamp-20170830-3.7.x.zip
RUN rm rabbitmq_message_timestamp-20170830-3.7.x.zip

RUN rabbitmq-plugins enable rabbitmq_message_timestamp rabbitmq_shovel
