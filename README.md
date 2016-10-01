# Sorkin Causal Sets

An updated version on the program referenced in the paper http://www.phy.olemiss.edu/~luca/Papers/Bombelli_1987_PhD.pdf by Luca Bombelli

Excerpt:

The program (originally by Luca Bombelli and D. Meyer)

The points in n-dimensional Minkowski space from which we want to obtain a realization of P = {p(i)} are represented as spheres, the intersection of a t = const hyperplane with the past light cones of the points, with radius R(i) and center at x(a)(i). Thus, in a causal embedding of P, p(i) -< p(j) iff -(R(j) - R(i))^2 + SUM<a=1 to n-1>(x(a)(j) - x(a)(i))^2 < 0 and R(i) < R(j).  The solution given here to the problem of the choice of energy and reconfiguration algorithm can be best understood if we start from the latter.  Once the program decides whether a particular sphere is to be moved in a reconfiguration (this happens with a probability depending on how correctly it is related to the others, which actually makes ours a "biased annealing", nor really thermal), the position of the sphere is changed from the current one by a normally distrubuted displacement in a uniformly random direction in space, and the radius is changed to a new value, normally distrubuted around the current one.  The displacement of the sphere looks therefore like a random displacement in n-dimensional Euclidean space, and the contribution to the energy due to a pair of points has been chosen accordingly, to be proportional to the minimum euclidean distance one of them has to move in this space in order to be correctly related to the other.  More details can be found by looking at the listing of the program.

A more satisfactory choice of displacements and energy would use in a more direct way the lorentzian nature of the Minkowski metric, and an improved version of the program will be written, taking this fact into account.  The present version of the program finds correct embeddings of simple causal sets, like the embedding of the six-element crown P(c)(6) = P(DM)(3) in 3 dimensions, but does not converge to a correct embedding for more complicated causal sets.

