
==============================
Crowd prototype v0.1
----------------
Ici est repr�sent� sommairement un ch�teau assi�g� par des assaillants (des piquiers).

Ces assaillants sont sous la forme de sprites avec un colider cube et un rigidbody. 
Ils se dirigent par moveToward vers le c�ur du ch�teau, ici un cube rouge. On leur applique une force vers le haut quand ils touchent quelque chose (le sol par exemple).
Ils disparaissent en � laissant s�envoler leur �me � quand ils touchent ce c�ur et les points de vie du ch�teau sont r�duits. Quand les points de vie atteignent 0, ma sc�ne se relance.

Des spawners plac�s dans la sc�ne cr�ent des assaillants en groupe (ici de 5, 10, 15).

Le but de ce prototype est de tester le rendu d�une foule d�assaillants et de tester les interactions physiques entre cette foule et le joueur en r�alit� virtuelle.