# Projet de peinture en VR - Unity

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)

Le projet de peinture effectué dans le cadre du projet de la derniere année pour le module de vision et réalité augmentée. Il s'agit d'une expérience immersive de peinture en réalité virtuelle. Les joueurs peuvent se téléporter dans un atelier virtuel et utiliser différents outils pour peindre des œuvres d'art numériques. 

*Le rendu de ce projet est prevu pour le 20/03/2023.*


# Sommaire des fonctionnalités
- [Interactions de peinture différentes](#interactions-de-peinture-diffrentes)
- [Palette de couleurs](#palette-de-couleurs)
- [Selection d'outil souhaité en l'attrapant](#selection-doutil-souhait-en-lattrapant)
- [Fonctionnalité supplementaire](#fonctionnalit-supplementaire)

## Interactions de peinture différentes
[*(Back to top)*](#table-of-contents)

| Démonstration | Explication |
|---------|---------|
| ![alt text 1](GitImage/) | **Pinceau** : Pour peindre|
| ![alt text 2](GitImage/) | **Spray** : Pour pulveriser la peinture|
| ![alt text 2](GitImage/) | **Baguette magique** : |


## Palette de couleurs 
[*(Back to top)*](#table-of-contents)

| Démonstration | Explication |
|---------|---------|
| ![alt text 1](GitImage/palette_mobile.gif) | **Mobile** : attachée à la main gauche|
| ![alt text 2](GitImage/) | **Couleurs** : Choix des couleurs|


## Selection d'outil souhaité en l'attrapant 
[*(Back to top)*](#table-of-contents)

## Mini-jeu permettant de reproduire le dessin
[(Back to top)](#table-of-contents)

Le mini-jeu permet de reproduire le dessin d'un tableau et obtenir un score de ressemblance. Pour obtenir ce score, le programme va comparer les 2 textures en calculant la différence de chaque canal de couleur (R, V, B et Alpha) pour chaque pixel, puis en calculant la moyenne de toutes les différences. 

Fonctionnement général :
```mermaid
 graph LR
    Hit_Shield --> Convert_Format_To_Texture
    Convert_Format_To_Texture --> Compare_Image
    Compare_Image --> Calculate_Percentage

``` 
| Démonstration | Explication |
|---------|---------|
| ![alt text 1](GitImage/teleportation.gif) | **Téléportation** : Sélectionner le rocher magique pour vous téléporter dans l'atelier, ou l'armoire magique pour retourner dans le monde originel|
| ![alt text 2](GitImage/) | **Taille du pinceau** : Peinture, possibilité de changer la taille (avec les pinceau accroché au mur à gauche) et la couleur du pinceau (palette)|
| ![alt text 2](GitImage/dessin_pomme.png) | **Score** : Dessiner une pomme puis sélectionner le bouclier magique pour obtenir votre score de ressemblance en pourcentage. |


## Fonctionnalité supplementaire 
[*(Back to top)*](#table-of-contents)


| Démonstration | Explication |
|---------|---------|
| ![alt text 1](GitImage/renard.gif) | **Renard** : parce que c'est trop mignon !! Regardez le faire ces petites roulades|



## Groupe

* [Sebila Doubaeva](https://github.com/taredalen)
* [Camille Bayon de Noyer](https://github.com/Kamomille)
* [Maelle Marcelin](https://github.com/maaelle)
* [Monia Moghraoui](https://github.com/SoniaMogh)


## Asset Store

* [Renard](https://assetstore.unity.com/packages/3d/characters/animals/toon-fox-183005)
* [Papillon](https://assetstore.unity.com/packages/3d/characters/animals/insects/butterfly-animated-58355)
* [Atelier du mini jeu](https://assetstore.unity.com/packages/3d/environments/cabin-environment-98014)
* [Village principal](https://assetstore.unity.com/packages/3d/environments/landscapes/rpg-poly-pack-lite-148410)
* [Table pour poser les outils](https://assetstore.unity.com/packages/3d/props/wooden-pbr-table-112005)

[(Back to top)](#sommaire-des-fonctionnalités)






