<!DOCTYPE html>
<html>
    <head>
      <meta charset="utf-8">
    	<meta http-equiv="X-UA-Compatible" content="IE=edge">
    	<meta name="viewport" content="width=device-width, initial-scale=1">
        <link href="css/bootstrap.min.css" rel="stylesheet">
        <link rel="stylesheet" type="text/css" href="styles.css">
        <!--<link rel="stylesheet" href="style.css" />-->
        <link rel="icon" type="image/png" href="images/drone.png">
        <title>Site Comparatif Drone</title>
        <script type="text/javascript" src="js/jquery.min.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script src="script.js.js"></script>
    </head>
<body>
<div class="navbar-wrapper">
      <div class="container">
        <nav class="navbar navbar-inverse navbar-static-top">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Afficher menu</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              <a class="navbar-brand" href="#">ComparaDrone</a>
            </div>
            <div id="navbar" class="navbar-collapse collapse">
              <ul class="nav navbar-nav">
                <li class="active"><a href="#">Home</a></li>
                <li><a href="#login">Login</a></li>
                <li><a href="#about">About</a></li>
                <li><a href="#contact">Contact</a></li>               
              </ul>
            </div>
          </div>
        </nav>
      </div>
    </div>
    <div id="myCarousel" class="carousel slide">
      <div class="carousel-inner" role="listbox">
        <div class="item active">
          <div class="container">
            <div class="video_wrapper">
            	<video preload="auto" autoplay="true" loop="loop" muted="muted" volume="0">
						    <source src="videos/EssaiVid1.mp4" type="video/mp4">
					    </video>
            </div>
          </div>
        </div>
    </div>
    <div class="container">
    	<div class="col-md-3">
        <div class="tabl">

          <b>Marque Drone :</b><br /><br />
          <label><input type="radio" name="check1.0" value="Marque1" /> Marque n°1</label><br />
          <label><input type="radio" name="check1.1" value="Marque2" /> Marque n°2</label><br />
          <label><input type="radio" name="check1.2" value="Marque3" /> Marque n°3</label><br />
          <label><input type="radio" name="check1.3" value="Marque4" /> Marque n°4</label>
          <br /><br />

          <b>Gamme Pro/Particulier : </b><br /><br />
          <label><input type="radio" name="check2" value="Pro" /> Profesionnel</label><br />
          <label><input type="radio" name="check2" value="Particulier" /> Particulier</label>
          <br /><br />

          <b>Poids :</b><br /><br />
          <label><input type="radio" name="check3" value="leger" /> Léger</label><br />
          <label><input type="radio" name="check3" value="semi-lourd" /> Semi-Lourd</label><br />
          <label><input type="radio" name="check3" value="lourd" /> Lourd</label>
          <br /><br />

          <b>Prix :</b><br /><br />
          <label><input type="radio" name="check4" value="Marque1" /> Moins de 500€</label><br />
          <label><input type="radio" name="check4" value="Marque2" /> Entre 500 et 1000€</label><br />
          <label><input type="radio" name="check4" value="Marque3" /> Entre 1000€ et 2000€</label><br />
          <label><input type="radio" name="check4" value="Marque4" /> Plus de 2000€</label>
          <br /><br />
        </div>
    	</div>
    	<div class="col-md-9">
        <?php
        	try
        	{
        		// Connection a MySQL
        		$bdd = new PDO('mysql:host=localhost;dbname=base_drone;charset=utf8', 'dev', 'dev');
        	}
        	catch (Exception $e)
        	{
        		// En cas d'erreur, on affiche un message et on arrête tout
        		die('Erreur : ' . $e->getMessage());
        	}
        	// On récupère tout le contenu de la table 'Drone'
        	$reponse = $bdd->query('SELECT * FROM Drone');
        	
        	while ($donnees = $reponse->fetch())
        	{
        		?>
        		<p>      		
        		<strong>Id</strong> : <?php echo $donnees['id_drone']; ?><br />
        		<strong>Img</strong> : <?php echo $donnees['img_drone']; ?><br />
        		<strong>Prixx</strong> : <?php echo $donnees['prix_drone']; ?><br />
        		<strong>Marque</strong> : <?php echo $donnees['marque_drone']; ?><br />
        		<strong>Nom</strong> : <?php echo $donnees['name_drone']; ?><br />
        		</p>
        		<?php
        	}

        	$reponse->closeCursor(); // Termine le traitement de la requête
        ?> 
      </div>
    </div>
</body>
</html>