namespace Utility
{
    public enum Sentido
    {
        Derecha = 0,
        Izquierda = 1,
        Recto
    }

    public struct Direccion
    {
        public Sentido sentido;
        public int destino; //Esto se cambiar�? Posiblemente
    }
}