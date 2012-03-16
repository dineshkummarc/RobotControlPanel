BEGIN TRANSACTION;

INSERT INTO cmds VALUES(1,'cmdStepForward',1,NULL);
INSERT INTO cmds VALUES(2,'cmdStepBackward',2,NULL);
INSERT INTO cmds VALUES(3,'cmdGoForward',3,NULL);
INSERT INTO cmds VALUES(4,'cmdGoBackward',4,NULL);
INSERT INTO cmds VALUES(5,'cmdStop',5,NULL);
INSERT INTO cmds VALUES(6,'cmdEStop',10,NULL);
INSERT INTO cmds VALUES(7,'cmdiSimple',111,NULL);

INSERT INTO parameters VALUES(1,'speed',-128,127,0,NULL);
INSERT INTO parameters VALUES(2,'turn',-128,127,0,NULL);
INSERT INTO parameters VALUES(3,'estop',NULL,NULL,1,NULL);
INSERT INTO parameters VALUES(4,'cmdisimple',NULL,NULL,1,NULL);
INSERT INTO parameters VALUES(5,'kamuparam',12,12,NULL,NULL);

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

INSERT INTO groupboxes VALUES(1,'Direction',1);
INSERT INTO groupboxes VALUES(2,'Control',2);
INSERT INTO groupboxes VALUES(3,'kamu',3);

INSERT INTO groupboxes_manifest VALUES(2,13);
INSERT INTO groupboxes_manifest VALUES(2,14);
INSERT INTO groupboxes_manifest VALUES(2,15);

INSERT INTO controlmode VALUES(1,1,'move',8,11,10,9,12,1,'controlmodecommentje');
INSERT INTO controlmode VALUES(2,2,'step',4,7,6,5,12,1,NULL);

INSERT INTO signs VALUES(1,'signStart',85,NULL);
INSERT INTO signs VALUES(2,'signStop',170,NULL);

INSERT INTO syntax VALUES(1,1,'sign');
INSERT INTO syntax VALUES(2,2,'params cmd');
INSERT INTO syntax VALUES(3,3,'cmd');
INSERT INTO syntax VALUES(4,4,'allparams');
INSERT INTO syntax VALUES(5,5,'sign');

INSERT INTO sign_syntax VALUES(1,1);
INSERT INTO sign_syntax VALUES(2,5);

INSERT INTO settings VALUES(9600,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);

INSERT INTO metadata VALUES(2,'author','Mukli Krisztián <krisztian.mukli@gmail.com>');
INSERT INTO metadata VALUES(3,'database version',3.1);

COMMIT;
