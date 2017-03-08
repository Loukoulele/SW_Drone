-- phpMyAdmin SQL Dump
-- version 4.6.4
-- https://www.phpmyadmin.net/
--
-- Client :  localhost
-- Généré le :  Mer 08 Mars 2017 à 17:25
-- Version du serveur :  5.6.28
-- Version de PHP :  7.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Base de données :  `SWD_bd`
--

-- --------------------------------------------------------

--
-- Structure de la table `Categorie`
--

CREATE TABLE `Categorie` (
  `n_cat` int(11) NOT NULL,
  `nom_cat` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `Categorie`
--

INSERT INTO `Categorie` (`n_cat`, `nom_cat`) VALUES
(1, 'Drones Débutants'),
(2, 'Drones Loisirs'),
(3, 'Drones FPV Racing'),
(4, 'Drones Professionnels');

-- --------------------------------------------------------

--
-- Structure de la table `Commande`
--

CREATE TABLE `Commande` (
  `n_commande` int(11) NOT NULL,
  `date_commande` date DEFAULT NULL,
  `etat_commande` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `Commande`
--

INSERT INTO `Commande` (`n_commande`, `date_commande`, `etat_commande`) VALUES
(1, '2017-03-08', 'en cours');

-- --------------------------------------------------------

--
-- Structure de la table `ligne_de_commande`
--

CREATE TABLE `ligne_de_commande` (
  `qte` int(11) DEFAULT NULL,
  `prix_effectif` double DEFAULT NULL,
  `n_commande` int(11) NOT NULL,
  `ref_prod` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `ligne_de_commande`
--

INSERT INTO `ligne_de_commande` (`qte`, `prix_effectif`, `n_commande`, `ref_prod`) VALUES
(2, 519.99, 1, 3);

-- --------------------------------------------------------

--
-- Structure de la table `passer`
--

CREATE TABLE `passer` (
  `n_user` int(11) NOT NULL,
  `n_commande` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `passer`
--

INSERT INTO `passer` (`n_user`, `n_commande`) VALUES
(1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `Produit`
--

CREATE TABLE `Produit` (
  `ref_prod` int(11) NOT NULL,
  `designation` varchar(25) DEFAULT NULL,
  `description` varchar(25) DEFAULT NULL,
  `image` varchar(25) DEFAULT NULL,
  `qte_stock` int(11) DEFAULT NULL,
  `prix` double DEFAULT NULL,
  `type_multirotor` varchar(25) DEFAULT NULL,
  `nbr_moteur` int(11) DEFAULT NULL,
  `Pas_des_Helice` varchar(25) DEFAULT NULL,
  `Poids_g_` int(11) DEFAULT NULL,
  `Autonomie` varchar(25) DEFAULT NULL,
  `n_cat` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `Produit`
--

INSERT INTO `Produit` (`ref_prod`, `designation`, `description`, `image`, `qte_stock`, `prix`, `type_multirotor`, `nbr_moteur`, `Pas_des_Helice`, `Poids_g_`, `Autonomie`, `n_cat`) VALUES
(0, NULL, NULL, NULL, NULL, 200, NULL, NULL, NULL, NULL, NULL, NULL),
(1, NULL, NULL, NULL, NULL, 300, NULL, NULL, NULL, NULL, NULL, NULL),
(2, 'Produit : Drone 1', 'Drone excellent pour kev', 'Jai ap :(', 45, 499, 'Acrobranche', 12, 'Avancé', 350, '450', 1),
(3, 'Produit : Drone 1', 'Drone excellent pour kev', 'Jai ap :(', 45, 499.99, 'Acrobranche', 12, 'Avancé', 350, '450', 1);

-- --------------------------------------------------------

--
-- Structure de la table `Utilisateur`
--

CREATE TABLE `Utilisateur` (
  `n_user` int(11) NOT NULL,
  `nom` varchar(250) DEFAULT NULL,
  `prenom` varchar(250) DEFAULT NULL,
  `adresse` varchar(250) DEFAULT NULL,
  `dpt` int(11) DEFAULT NULL,
  `ville` varchar(250) DEFAULT NULL,
  `mail` varchar(250) DEFAULT NULL,
  `tel` int(11) DEFAULT NULL,
  `pseudo` varchar(250) DEFAULT NULL,
  `mdp` varchar(250) DEFAULT NULL,
  `type_user` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Contenu de la table `Utilisateur`
--

INSERT INTO `Utilisateur` (`n_user`, `nom`, `prenom`, `adresse`, `dpt`, `ville`, `mail`, `tel`, `pseudo`, `mdp`, `type_user`) VALUES
(1, 'Conan', 'Kevin', '43 rue du cul', 77420, 'Champs Sur Marne', 'kevin-69@hotmail.fr', 669696969, 'KeGland', 'kevzizi', 'admin');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `Categorie`
--
ALTER TABLE `Categorie`
  ADD PRIMARY KEY (`n_cat`);

--
-- Index pour la table `Commande`
--
ALTER TABLE `Commande`
  ADD PRIMARY KEY (`n_commande`);

--
-- Index pour la table `ligne_de_commande`
--
ALTER TABLE `ligne_de_commande`
  ADD PRIMARY KEY (`n_commande`,`ref_prod`),
  ADD KEY `FK_ligne_de_commande_ref_prod` (`ref_prod`);

--
-- Index pour la table `passer`
--
ALTER TABLE `passer`
  ADD PRIMARY KEY (`n_user`,`n_commande`),
  ADD KEY `FK_passer_n_commande` (`n_commande`);

--
-- Index pour la table `Produit`
--
ALTER TABLE `Produit`
  ADD PRIMARY KEY (`ref_prod`),
  ADD KEY `FK_Produit_n_cat` (`n_cat`);

--
-- Index pour la table `Utilisateur`
--
ALTER TABLE `Utilisateur`
  ADD PRIMARY KEY (`n_user`);

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `ligne_de_commande`
--
ALTER TABLE `ligne_de_commande`
  ADD CONSTRAINT `FK_ligne_de_commande_n_commande` FOREIGN KEY (`n_commande`) REFERENCES `Commande` (`n_commande`),
  ADD CONSTRAINT `FK_ligne_de_commande_ref_prod` FOREIGN KEY (`ref_prod`) REFERENCES `Produit` (`ref_prod`);

--
-- Contraintes pour la table `passer`
--
ALTER TABLE `passer`
  ADD CONSTRAINT `FK_passer_n_commande` FOREIGN KEY (`n_commande`) REFERENCES `Commande` (`n_commande`),
  ADD CONSTRAINT `FK_passer_n_user` FOREIGN KEY (`n_user`) REFERENCES `Utilisateur` (`n_user`);

--
-- Contraintes pour la table `Produit`
--
ALTER TABLE `Produit`
  ADD CONSTRAINT `FK_Produit_n_cat` FOREIGN KEY (`n_cat`) REFERENCES `Categorie` (`n_cat`);