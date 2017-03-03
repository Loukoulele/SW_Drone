#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: Utilisateur
#------------------------------------------------------------

CREATE TABLE Utilisateur(
        n_user    Int NOT NULL ,
        nom       Varchar (250) ,
        prenom    Varchar (250) ,
        adresse   Varchar (250) ,
        dpt       Int ,
        ville     Varchar (250) ,
        mail      Varchar (250) ,
        tel       Int ,
        pseudo    Varchar (250) ,
        mdp       Varchar (250) ,
        type_user Varchar (25) ,
        PRIMARY KEY (n_user )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Commande
#------------------------------------------------------------

CREATE TABLE Commande(
        n_commande    Int NOT NULL ,
        date_commande Date ,
        etat_commande Varchar (25) ,
        PRIMARY KEY (n_commande )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Produit
#------------------------------------------------------------

CREATE TABLE Produit(
        ref_prod        Int NOT NULL ,
        designation     Varchar (25) ,
        description     Varchar (25) ,
        image           Varchar (25) ,
        qte_stock       Int ,
        prix            Double ,
        type_multirotor Varchar (25) ,
        nbr_moteur      Int ,
        Pas_des_Helice  Varchar (25) ,
        Poids_g_        Int ,
        Autonomie       Varchar (25) ,
        n_cat           Int ,
        PRIMARY KEY (ref_prod )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Categorie
#------------------------------------------------------------

CREATE TABLE Categorie(
        n_cat   Int NOT NULL ,
        nom_cat Varchar (25) ,
        PRIMARY KEY (n_cat )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: passer
#------------------------------------------------------------

CREATE TABLE passer(
        n_user     Int NOT NULL ,
        n_commande Int NOT NULL ,
        PRIMARY KEY (n_user ,n_commande )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: ligne de commande
#------------------------------------------------------------

CREATE TABLE ligne_de_commande(
        qte           Int ,
        prix_effectif Double ,
        n_commande    Int NOT NULL ,
        ref_prod      Int NOT NULL ,
        PRIMARY KEY (n_commande ,ref_prod )
)ENGINE=InnoDB;

ALTER TABLE Produit ADD CONSTRAINT FK_Produit_n_cat FOREIGN KEY (n_cat) REFERENCES Categorie(n_cat);
ALTER TABLE passer ADD CONSTRAINT FK_passer_n_user FOREIGN KEY (n_user) REFERENCES Utilisateur(n_user);
ALTER TABLE passer ADD CONSTRAINT FK_passer_n_commande FOREIGN KEY (n_commande) REFERENCES Commande(n_commande);
ALTER TABLE ligne_de_commande ADD CONSTRAINT FK_ligne_de_commande_n_commande FOREIGN KEY (n_commande) REFERENCES Commande(n_commande);
ALTER TABLE ligne_de_commande ADD CONSTRAINT FK_ligne_de_commande_ref_prod FOREIGN KEY (ref_prod) REFERENCES Produit(ref_prod);
