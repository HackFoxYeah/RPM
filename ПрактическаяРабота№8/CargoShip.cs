namespace practWork_8
{
    internal class CargoShip : IShip, ICloneable, IComparable, ICargoTransport
    {
        public enum FuelType
        {
            steam = 1,
            diesel,
            nuclearPower
        };

        private double
               _length,
               _weigth,
               _width,
               _cargoCapacity,
               _loadCapacity,
               _enginePower;

        private string _name;

        private FuelType _fuelType;

        public double Length
        { get => _length; set => _length = value; }
        public double Weigth
        { get => _weigth; set => _weigth = value; }
        public double Width
        { get => _width; set => _width = value; }
        public double EnginePower
        { get => _enginePower; set => _enginePower = value; }
        public double CargoCapacity
        { get => _cargoCapacity; set => _cargoCapacity = value; }
        public double LoadCapacity
        { get => _loadCapacity; set => _loadCapacity = value; }
        public string Name
        { get => _name; set => _name = value; }
        public FuelType FType
        { get => _fuelType; set => _fuelType = value; }

        public CargoShip()
        {
            _length = default;
            _width = default;
            _cargoCapacity = default;
            _loadCapacity = default;
            _name = default;
            _weigth = default;
            _enginePower = default;
            _fuelType = default;
        }

        public CargoShip(CargoShip obj) //Копирующий конструктор (аналог метода Clone()).
        {
            _length = obj.Length;
            _width = obj.Width;
            _cargoCapacity = obj.CargoCapacity;
            _loadCapacity = obj.LoadCapacity;
            _name = obj.Name;
            _weigth = obj.Weigth;
            _enginePower = obj.EnginePower;
            _fuelType = obj.FType;
        }

        public CargoShip(string name, double length, double width, double loadCap, double cargoCap, double enginePower, double weigth, in FuelType fuelType)
        {
            _length = length;
            _width = width;
            _cargoCapacity = cargoCap;
            _loadCapacity = loadCap;
            _name = name;
            _weigth = weigth;
            _enginePower = enginePower;
            _fuelType = fuelType;
        }

        /// <summary>
        /// Сравнивает два объекта класса CargoShip.
        /// </summary>
        /// <param name="obj">Экземпляр класса object.</param>
        /// <returns>Целое число.</returns>
        public int CompareTo(in object obj)
        {
            CargoShip tempObj = obj as CargoShip;

            if (LoadCapacity > tempObj.LoadCapacity)
                return 1;
            else if (LoadCapacity < tempObj.LoadCapacity)
                return -1;

            return 0;
        }

        public object Clone() //реализация интерфейса ICloneable
        {
            return new CargoShip()
            {
                Name = _name,
                Weigth = _weigth,
                Length = _length,
                CargoCapacity = _cargoCapacity,
                LoadCapacity = _loadCapacity,
                EnginePower = _enginePower,
                Width = _width,
                FType = _fuelType
            };
        }

        public static bool operator <(CargoShip first, CargoShip second)
        {
            return first.LoadCapacity < second.LoadCapacity;
        }

        public static bool operator >(CargoShip first, CargoShip second)
        {
            return first.LoadCapacity > second.LoadCapacity;
        }
    }
}