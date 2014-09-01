NBS_Day
=======

Setting up repo

Simple placeholder.

* Thoughts
 - One queue for each message, better for scaling..(One end-point for message...)
 - Client and server is decoupled (comms through queue)
 - Bus.Send writes to local outboox. Its MSMQ responsibility to write to remote Incoming queue.
 - Messages are expired based on TimeToBeReceived attribute. 
 - Dead letter queue is used to store expired messages. Use with care.
