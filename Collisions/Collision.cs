namespace RPG
{
    struct Collision
    {
        public Enemy enemy;
        public Projectile projectile;

        public Collision(Enemy enemy, Projectile projectile)
        {
            this.enemy = enemy;
            this.projectile = projectile;
        }
    }
}
