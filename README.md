NBS_Day
=======

* Notes
 - One queue for each message, better for scaling..(One end-point for message...)
 - Client and server is decoupled (comms through queue)
 - Bus.Send writes to local outboox. Its MSMQ responsibility to write to remote Incoming queue.
 - Messages are expired based on TimeToBeReceived attribute. 
 - Dead letter queue is used to store expired messages. Use with care.
 - Queue Explorer is a useful tool for exploring queues.
 - Poison message are messages that cannot be processed and prevents other messages from processing. 
 - First level/second level retries. (puts these messages in RavenDB and brings it back)
 - Moves messages to "error" queue if all the policies are exhousted. (Endpoint wide exception policies)
 - 4MB message size, including headers. 
 - Headers can be set at message or for all messages.
 - Message pipe line can attach multiple handlers.
 - Beaware of the IManageUnitsOfWork, this is changing in V5.
 - IMessageMutators pulg in to messages that is sent out/in.
 - IMutateTransportMessages, this can be used for provide message level transport work (e.g. ProtoBuf)
 - Allows plug-in of our own Ioc framework. Looks like there are extensions for Ninject. Need to search around Windsor.
 - Encryption, WireEncryptedString, should be used for string level encryption. Rijndael encryption is built in (shared key). 
 - AsA_Client and AsA_Server are roles. We can create our own roles. These roles contain customised configuration.
 - Profiles allow changing endpoint behaviour without recompiling. (Environment specific configuration)
 - IProvideConfiguration can be used to override configuration sections. (good for stateless servers.)
 - For unit testing use normal testing. Simply create a dummy IBus. Do not stub to IBus.
