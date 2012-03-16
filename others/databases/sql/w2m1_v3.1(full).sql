BEGIN TRANSACTION;
CREATE TABLE [cmds] ([cmdID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdName] TEXT NOT NULL UNIQUE, [cmdByte] INTEGER NOT NULL, [cmdComment] TEXT);
INSERT INTO cmds VALUES(1,'cmdStepForward',1,NULL);
INSERT INTO cmds VALUES(2,'cmdStepBackward',2,NULL);
INSERT INTO cmds VALUES(3,'cmdGoForward',3,NULL);
INSERT INTO cmds VALUES(4,'cmdGoBackward',4,NULL);
INSERT INTO cmds VALUES(5,'cmdStop',5,NULL);
INSERT INTO cmds VALUES(6,'cmdEStop',10,NULL);
INSERT INTO cmds VALUES(7,'cmdiSimple',111,NULL);
CREATE TABLE [controlmode] ([controlmodeID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [controlmodeOrder] INTEGER NOT NULL, [controlmodeName] TEXT NOT NULL, [controlmodeUp] INTEGER CONSTRAINT [controlmodeUp] REFERENCES [manifest]([manifestID]), [controlmodeDown] INTEGER CONSTRAINT [controlmodeDown] REFERENCES [manifest]([manifestID]), [controlmodeRight] INTEGER CONSTRAINT [controlmodeRight] REFERENCES [manifest]([manifestID]), [controlmodeLeft] INTEGER CONSTRAINT [controlmodeLeft] REFERENCES [manifest]([manifestID]), [controlmodeStop] INTEGER CONSTRAINT [controlmodeStop] REFERENCES [manifest]([manifestID]), [groupboxID] INTEGER NOT NULL CONSTRAINT [groupboxID] REFERENCES [groupboxes]([groupboxID]) ON DELETE CASCADE ON UPDATE CASCADE, [controlmodeComment] TEXT);
INSERT INTO controlmode VALUES(1,1,'move',8,11,10,9,12,1,'controlmodecommentje');
INSERT INTO controlmode VALUES(2,2,'step',4,7,6,5,12,1,NULL);
CREATE TABLE [groupboxes] ([groupboxID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [groupboxName] TEXT NOT NULL, [groupboxOrder] INTEGER NOT NULL UNIQUE);
INSERT INTO groupboxes VALUES(1,'Direction',1);
INSERT INTO groupboxes VALUES(2,'Control',2);
INSERT INTO groupboxes VALUES(3,'kamu',3);
CREATE TABLE [groupboxes_manifest] ([groupboxID] INTEGER NOT NULL CONSTRAINT [groupboxID] REFERENCES [groupboxes]([groupboxID]) ON DELETE CASCADE ON UPDATE CASCADE, [manifestID] INTEGER NOT NULL CONSTRAINT [manifestID] REFERENCES [manifest]([manifestID]) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT [sqlite_autoindex_groupboxes_manifest_1] PRIMARY KEY ([groupboxID], [manifestID]));
INSERT INTO groupboxes_manifest VALUES(2,13);
INSERT INTO groupboxes_manifest VALUES(2,14);
INSERT INTO groupboxes_manifest VALUES(2,15);
CREATE TABLE [manifest] ([manifestID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdID] INTEGER NOT NULL CONSTRAINT [cmdID] REFERENCES [cmds]([cmdID]) ON DELETE CASCADE ON UPDATE CASCADE, [manifestType] TEXT NOT NULL, [manifestComment] TEXT);
INSERT INTO manifest VALUES(4,1,'button','Zefgygomb');
INSERT INTO manifest VALUES(5,1,'button',NULL);
INSERT INTO manifest VALUES(6,1,'button',NULL);
INSERT INTO manifest VALUES(7,2,'button',NULL);
INSERT INTO manifest VALUES(8,3,'button',NULL);
INSERT INTO manifest VALUES(9,3,'button',NULL);
INSERT INTO manifest VALUES(10,3,'button',NULL);
INSERT INTO manifest VALUES(11,4,'button',NULL);
INSERT INTO manifest VALUES(12,5,'button',NULL);
INSERT INTO manifest VALUES(13,6,'button',NULL);
INSERT INTO manifest VALUES(14,7,'button',NULL);
INSERT INTO manifest VALUES(15,6,'button',NULL);
CREATE TABLE [manifest_parameter] ([manifestID] INTEGER NOT NULL CONSTRAINT [manifestID] REFERENCES [manifest]([manifestID]), [parameter_cmdID] INTEGER NOT NULL CONSTRAINT [parameter_cmdID] REFERENCES [parameter_cmd]([parameter_cmdID]), [manifest_parameterValue] INTEGER, [manifest_parameterType] TEXT, [manifest_parameterComment] TEXT, CONSTRAINT [sqlite_autoindex_manifest_parameters_1] PRIMARY KEY ([manifestID], [parameter_cmdID]));
INSERT INTO manifest_parameter VALUES(4,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(4,2,0,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(5,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(5,2,-5,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(6,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(6,2,5,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(7,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(7,2,0,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(8,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(8,2,0,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(9,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(9,2,-5,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(10,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(10,2,5,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(11,1,10,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(11,2,0,'trackbar',NULL);
INSERT INTO manifest_parameter VALUES(13,9,NULL,NULL,'ez csak kamu');
INSERT INTO manifest_parameter VALUES(14,10,NULL,NULL,NULL);
INSERT INTO manifest_parameter VALUES(15,9,0,NULL,NULL);
INSERT INTO manifest_parameter VALUES(15,11,8,NULL,NULL);
CREATE TABLE [metadata] ([metadataID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [metadataField] TEXT NOT NULL, [metadataValue] TEXT);
INSERT INTO metadata VALUES(1,'software','Robot Control Panel v0.12');
INSERT INTO metadata VALUES(2,'author','Mukli Krisztián <krisztian.mukli@gmail.com>');
INSERT INTO metadata VALUES(3,'database version',3.1);
CREATE TABLE [parameter_cmd] ([parameter_cmdID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [cmdID] INTEGER NOT NULL CONSTRAINT [cmdID] REFERENCES [cmds]([cmdID]) ON DELETE CASCADE ON UPDATE CASCADE, [parameterID] INTEGER NOT NULL CONSTRAINT [parameterID] REFERENCES [parameters]([parameterID]) ON DELETE CASCADE ON UPDATE CASCADE, [parameter_cmdOrder] INTEGER NOT NULL);
INSERT INTO parameter_cmd VALUES(1,1,1,1);
INSERT INTO parameter_cmd VALUES(2,1,2,2);
INSERT INTO parameter_cmd VALUES(3,2,1,1);
INSERT INTO parameter_cmd VALUES(4,2,2,2);
INSERT INTO parameter_cmd VALUES(5,3,1,1);
INSERT INTO parameter_cmd VALUES(6,3,2,2);
INSERT INTO parameter_cmd VALUES(7,4,1,1);
INSERT INTO parameter_cmd VALUES(8,4,2,2);
INSERT INTO parameter_cmd VALUES(9,6,3,1);
INSERT INTO parameter_cmd VALUES(10,7,4,1);
INSERT INTO parameter_cmd VALUES(11,6,5,2);
CREATE TABLE [parameters] ([parameterID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [parameterName] TEXT NOT NULL UNIQUE, [parameterMin] INTEGER, [parameterMax] INTEGER, [parameterDefault] INTEGER, [parameterComment] TEXT);
INSERT INTO parameters VALUES(1,'speed',-128,127,0,NULL);
INSERT INTO parameters VALUES(2,'turn',-128,127,0,NULL);
INSERT INTO parameters VALUES(3,'estop',NULL,NULL,1,NULL);
INSERT INTO parameters VALUES(4,'cmdisimple',NULL,NULL,1,NULL);
INSERT INTO parameters VALUES(5,'kamuparam',12,12,NULL,NULL);
CREATE TABLE [settings] ([baudRate] INTEGER, [dataBits] INTEGER, [discardNull] BOOLEAN, [dtrEnable] BOOLEAN, [handShake] INTEGER, [parity] INTEGER, [parityReplace] INTEGER, [portName] TEXT, [readBufferSize] INTEGER, [readTimeOut] INTEGER, [receivedBytesThreshold] INTEGER, [rtsEnable] BOOLEAN, [stopBits] INTEGER, [writeBufferSize] INTEGER, [writeTimeout] INTEGER);
INSERT INTO settings VALUES(9600,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
CREATE TABLE [sign_syntax] ([signID] INTEGER NOT NULL CONSTRAINT [signID] REFERENCES [signs]([signID]) ON DELETE CASCADE ON UPDATE CASCADE, [syntaxID] INTEGER NOT NULL CONSTRAINT [syntaxID] REFERENCES [syntax]([syntaxID]) ON DELETE CASCADE ON UPDATE CASCADE, CONSTRAINT [] PRIMARY KEY ([signID], [syntaxID]));
INSERT INTO sign_syntax VALUES(1,1);
INSERT INTO sign_syntax VALUES(2,5);
CREATE TABLE [signs] ([signID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [signName] TEXT NOT NULL UNIQUE, [signByte] INTEGER NOT NULL, [signComment] TEXT);
INSERT INTO signs VALUES(1,'signStart',85,NULL);
INSERT INTO signs VALUES(2,'signStop',170,NULL);
CREATE TABLE sqlite_sequence(name,seq);
INSERT INTO sqlite_sequence VALUES('metadata',3);
INSERT INTO sqlite_sequence VALUES('cmds',7);
INSERT INTO sqlite_sequence VALUES('parameters',5);
INSERT INTO sqlite_sequence VALUES('parameter_cmd',11);
INSERT INTO sqlite_sequence VALUES('manifest',15);
INSERT INTO sqlite_sequence VALUES('groupboxes',3);
INSERT INTO sqlite_sequence VALUES('controlmode',2);
INSERT INTO sqlite_sequence VALUES('signs',2);
INSERT INTO sqlite_sequence VALUES('syntax',5);
CREATE TABLE [syntax] ([syntaxID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, [syntaxOrder] INTEGER NOT NULL UNIQUE, [syntaxType] TEXT NOT NULL);
INSERT INTO syntax VALUES(1,1,'sign');
INSERT INTO syntax VALUES(2,2,'params cmd');
INSERT INTO syntax VALUES(3,3,'cmd');
INSERT INTO syntax VALUES(4,4,'allparams');
INSERT INTO syntax VALUES(5,5,'sign');
COMMIT;
