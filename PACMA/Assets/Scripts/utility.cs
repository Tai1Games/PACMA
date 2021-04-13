namespace Utility
{
    public enum Sentido
    {
        Derecha = 0,
        Izquierda = 1
    }

    public struct Direccion
    {
        public Sentido sentido;
        public int destino; //Esto se cambiará? Posiblemente
    }
}