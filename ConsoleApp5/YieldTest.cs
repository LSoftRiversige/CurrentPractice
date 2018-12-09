using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class Car
    {
        public string Model { get; set; }

        public override string ToString()
        {
            return Model;
        }
    }

    class YieldTest: IEnumerable<Car>
    {
        public IEnumerable<Car> GetCars()
        {
            yield return new Car() { Model="Pathfinder"};
            yield return new Car() { Model="Toyeta"};
            yield return new Car() { Model="Huinday"};
        }

        public IEnumerator<Car> GetEnumerator()
        {
            yield return new Car() { Model = "Pathfinder" };
            yield return new Car() { Model = "Toyeta" };
            yield return new Car() { Model = "Huinday" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
