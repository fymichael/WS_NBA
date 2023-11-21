CREATE SCHEMA IF NOT EXISTS "public";

CREATE  TABLE "public".equipe ( 
	id_equipe            serial  NOT NULL  ,
	nom                  varchar(30)    ,
	localisation         varchar(30)    ,
	abreviation          varchar(10)    ,
	CONSTRAINT pk_equipe PRIMARY KEY ( id_equipe )
 );

CREATE  TABLE "public".joueur ( 
	id_joueur            serial  NOT NULL  ,
	nom                  varchar(30)    ,
	prenom               varchar(30)    ,
	dtn                  date    ,
	id_equipe            integer    ,
	numero               integer    ,
	poste                varchar(30)    ,
	CONSTRAINT pk_joueur PRIMARY KEY ( id_joueur ),
	CONSTRAINT fk_joueur_equipe FOREIGN KEY ( id_equipe ) REFERENCES "public".equipe( id_equipe )   
 );

CREATE  TABLE "public"."match" ( 
	id_match             serial  NOT NULL  ,
	id_equipe1           integer    ,
	id_equipe2           integer    ,
	etat_match           integer    ,
	CONSTRAINT pk_tbl_0 PRIMARY KEY ( id_match ),
	CONSTRAINT fk_match_equipe FOREIGN KEY ( id_equipe1 ) REFERENCES "public".equipe( id_equipe )   ,
	CONSTRAINT fk_match_equipe_0 FOREIGN KEY ( id_equipe2 ) REFERENCES "public".equipe( id_equipe )   
 );

CREATE  TABLE "public".statistique ( 
	id_match             integer    ,
	id_joueur            integer    ,
	passe_d              integer    ,
	point                integer    ,
	"minute"             integer    ,
	rebond               integer    ,
	CONSTRAINT fk_statistique_match FOREIGN KEY ( id_match ) REFERENCES "public"."match"( id_match )   ,
	CONSTRAINT fk_statistique_joueur FOREIGN KEY ( id_joueur ) REFERENCES "public".joueur( id_joueur )   
 );

INSERT INTO "public".equipe( id_equipe, nom, localisation, abreviation ) VALUES ( 1, 'Lakers', 'Miami', 'LAL');
INSERT INTO "public".equipe( id_equipe, nom, localisation, abreviation ) VALUES ( 2, 'Golden State', 'Los Angeles', 'GSW');
INSERT INTO "public".equipe( id_equipe, nom, localisation, abreviation ) VALUES ( 3, 'Clippers', 'Washington', 'LAC');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 1, 'Lebron', 'James', '1986-02-24', 1, 23, 'A');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 2, 'Anthony', 'Davies', '1982-09-25', 1, 3, 'P');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 3, 'Austin', 'Reaves', '1990-05-12', 1, 4, 'MJ');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 17, 'Kobe', 'Bryant', '1993-03-14', 1, 24, 'AI');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 7, 'Stephen', 'Curry', '1994-12-31', 2, 30, 'MJ');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 8, 'Klay', 'Thompson', '1995-01-01', 2, 10, 'A');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 13, 'Andre', 'Iguodala', '1987-04-12', 2, 0, 'AI');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 18, 'Draymond', 'Green', '1990-07-10', 2, 5, 'P');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 14, 'Kawhi', 'Leonard', '1987-04-12', 3, 12, 'AI');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 15, 'Paul', 'George', '1992-09-25', 3, 20, 'MJ');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 16, 'Russell', 'Westbrook', '1990-12-17', 3, 24, 'A');
INSERT INTO "public".joueur( id_joueur, nom, prenom, dtn, id_equipe, numero, poste ) VALUES ( 19, 'James', 'Harden', '1991-10-20', 3, 12, 'P');
INSERT INTO "public"."match"( id_match, id_equipe1, id_equipe2, etat_match ) VALUES ( 9, 1, 2, 1);
INSERT INTO "public"."match"( id_match, id_equipe1, id_equipe2, etat_match ) VALUES ( 10, 1, 3, 1);
INSERT INTO "public"."match"( id_match, id_equipe1, id_equipe2, etat_match ) VALUES ( 11, 3, 2, 1);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 1, 5, 5, 14, 1);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 2, 7, 4, 4, 3);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 3, 2, 3, 5, 5);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 17, 6, 8, 12, 0);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 7, 2, 9, 20, 4);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 8, 4, 4, 12, 7);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 13, 1, 5, 5, 0);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 9, 18, 0, 2, 8, 4);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 1, 2, 2, 3, 8);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 2, 1, 8, 8, 0);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 3, 8, 10, 15, 1);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 17, 2, 1, 7, 6);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 14, 2, 4, 12, 2);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 15, 4, 3, 5, 6);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 16, 1, 5, 7, 0);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 10, 19, 0, 2, 9, 5);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 7, 1, 3, 12, 3);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 8, 3, 5, 2, 5);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 13, 7, 8, 3, 6);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 18, 4, 6, 14, 2);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 14, 8, 2, 11, 1);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 15, 1, 4, 13, 7);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 16, 2, 1, 12, 7);
INSERT INTO "public".statistique( id_match, id_joueur, passe_d, point, "minute", rebond ) VALUES ( 11, 19, 5, 2, 4, 2);

create view v_statistique_personnel as
	select id_joueur, sum(passe_d) as passe_d,sum(point) as point,sum(minute) as minute,sum(rebond) as rebond
 from statistique 
group by id_joueur;