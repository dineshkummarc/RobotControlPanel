BEGIN TRANSACTION;
CREATE TABLE [cmds] ([cmdID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdName] TEXT NOT NULL UNIQUE, [cmdByte] INTEGER NOT NULL, [cmdComment] TEXT);
CREATE TABLE [controlmode] ([controlmodeID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [controlmodeOrder] INTEGER NOT NULL, [controlmodeName] TEXT NOT NULL, [controlmodeUp] INTEGER CONSTRAINT [controlmodeUp] REFERENCES [manifest]([manifestID]), [controlmodeDown] INTEGER CONSTRAINT [controlmodeDown] REFERENCES [manifest]([manifestID]), [controlmodeRight] INTEGER CONSTRAINT [controlmodeRight] REFERENCES [manifest]([manifestID]), [controlmodeLeft] INTEGER CONSTRAINT [controlmodeLeft] REFERENCES [manifest]([manifestID]), [controlmodeStop] INTEGER CONSTRAINT [controlmodeStop] REFERENCES [manifest]([manifestID]), [groupboxID] INTEGER NOT NULL CONSTRAINT [groupboxID] REFERENCES [groupboxes]([groupboxID]) ON DELETE CASCADE ON UPDATE CASCADE, [controlmodeComment] TEXT);
CREATE TABLE [groupboxes] ([groupboxID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [groupboxName] TEXT NOT NULL, [groupboxOrder] INTEGER NOT NULL UNIQUE);
CREATE TABLE [groupboxes_manifest] ([groupboxID] INTEGER NOT NULL CONSTRAINT [groupboxID] REFERENCES [groupboxes]([groupboxID]) ON DELETE CASCADE ON UPDATE CASCADE, [manifestID] INTEGER NOT NULL CONSTRAINT [manifestID] REFERENCES [manifest]([manifestID]) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT [sqlite_autoindex_groupboxes_manifest_1] PRIMARY KEY ([groupboxID], [manifestID]));
CREATE TABLE [manifest] ([manifestID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdID] INTEGER NOT NULL CONSTRAINT [cmdID] REFERENCES [cmds]([cmdID]) ON DELETE CASCADE ON UPDATE CASCADE, [manifestType] TEXT NOT NULL, [manifestComment] TEXT);
CREATE TABLE [manifest_parameter] ([manifestID] INTEGER NOT NULL CONSTRAINT [manifestID] REFERENCES [manifest]([manifestID]), [parameter_cmdID] INTEGER NOT NULL CONSTRAINT [parameter_cmdID] REFERENCES [parameter_cmd]([parameter_cmdID]), [manifest_parameterValue] INTEGER, [manifest_parameterType] TEXT, [manifest_parameterComment] TEXT, CONSTRAINT [sqlite_autoindex_manifest_parameters_1] PRIMARY KEY ([manifestID], [parameter_cmdID]));
CREATE TABLE [metadata] ([metadataID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [metadataField] TEXT NOT NULL, [metadataValue] TEXT);
INSERT INTO metadata VALUES(1,'software','Robot Control Panel v0.12');
CREATE TABLE [parameter_cmd] ([parameter_cmdID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdID] INTEGER NOT NULL CONSTRAINT [cmdID] REFERENCES [cmds]([cmdID]) ON DELETE CASCADE ON UPDATE CASCADE, [parameterID] INTEGER NOT NULL CONSTRAINT [parameterID] REFERENCES [parameters]([parameterID]) ON DELETE CASCADE ON UPDATE CASCADE, [parameter_cmdOrder] INTEGER NOT NULL);
CREATE TABLE [parameters] ([parameterID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [parameterName] TEXT NOT NULL UNIQUE, [parameterMin] INTEGER, [parameterMax] INTEGER, [parameterDefault] INTEGER, [parameterComment] TEXT);
CREATE TABLE [settings] ([baudRate] INTEGER, [dataBits] INTEGER, [discardNull] BOOLEAN, [dtrEnable] BOOLEAN, [handShake] INTEGER, [parity] INTEGER, [parityReplace] INTEGER, [portName] TEXT, [readBufferSize] INTEGER, [readTimeOut] INTEGER, [receivedBytesThreshold] INTEGER, [rtsEnable] BOOLEAN, [stopBits] INTEGER, [writeBufferSize] INTEGER, [writeTimeout] INTEGER);
CREATE TABLE [sign_syntax] ([signID] INTEGER NOT NULL CONSTRAINT [signID] REFERENCES [signs]([signID]) ON DELETE CASCADE ON UPDATE CASCADE, [syntaxID] INTEGER NOT NULL CONSTRAINT [syntaxID] REFERENCES [syntax]([syntaxID]) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT [] PRIMARY KEY ([signID], [syntaxID]));
CREATE TABLE [signs] ([signID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [signName] TEXT NOT NULL UNIQUE, [signByte] INTEGER NOT NULL, [signComment] TEXT);
CREATE TABLE sqlite_sequence(name,seq);
INSERT INTO sqlite_sequence VALUES('metadata',1);
CREATE TABLE [syntax] ([syntaxID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [syntaxOrder] INTEGER NOT NULL UNIQUE, [syntaxType] TEXT NOT NULL);
COMMIT;
