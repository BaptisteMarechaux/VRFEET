
==============================
Crowd prototype v0.1
----------------
Ici est représenté sommairement un château assiégé par des assaillants (des piquiers).

Ces assaillants sont sous la forme de sprites avec un colider cube et un rigidbody. 
Ils se dirigent par moveToward vers le cœur du château, ici un cube rouge. On leur applique une force vers le haut quand ils touchent quelque chose (le sol par exemple).
Ils disparaissent en « laissant s’envoler leur âme » quand ils touchent ce cœur et les points de vie du château sont réduits. Quand les points de vie atteignent 0, ma scène se relance.

Des spawners placés dans la scène créent des assaillants en groupe (ici de 5, 10, 15).

Le but de ce prototype est de tester le rendu d’une foule d’assaillants et de tester les interactions physiques entre cette foule et le joueur en réalité virtuelle.