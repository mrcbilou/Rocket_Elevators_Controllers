using System;
using System.Collections.Generic;

namespace Rocket_Elevator_Commercial_Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Battery battery = new Battery(4, 66, 5, -6);

            foreach (Column col in battery.columnList) {
                Console.WriteLine(col.id);
            }
        }
    }

    class Battery
    {
        // member variables
        int column_amount;
        int number_of_elevators_per_column;
        int floor_amount;
        int battery_lowest_floor;
        public List<Column> columnList = new List<Column>();

        public Battery(int _column_amount, int _floor_amount, int _amount_of_elevator_per_column, int _battery_lowest_floor  )
        {
            column_amount = _column_amount;
            number_of_elevators_per_column = _amount_of_elevator_per_column;
            floor_amount = _floor_amount;
            battery_lowest_floor = _battery_lowest_floor;

            for(int i = 1 ; i <= _column_amount; i++){
                Column col = new Column(_floor_amount, _battery_lowest_floor, _floor_amount + _battery_lowest_floor, i);
                columnList.Add(col);
            }
        }


        public void CreateCallButtonList()
        {

        }

        public void RequestElevator()
        {

        }

    }

    class Column
    {
        public int id;
        int floor_amount;
        int minimum_floor;
        int maximum_floor;

        public Column (int _floor_amount, int _minimum_floor, int _maximum_floor, int _id) {
            id = _id;
            floor_amount = _floor_amount;
            minimum_floor = _minimum_floor;
            maximum_floor = _maximum_floor;
        }

        public void CreateElevatorList()
        {

        }

        public void CreateFloorIndicatorList()
        {

        }

        public void CreateColumnGroupList()
        {

        }

        public void FindBestElevator()
        {

        }

    }

     class Elevator
    {
        double status;
        double current_floor;
        double direction;


        public void CreateRequestList()
        {

        }

        public void MoveElevator()
        {

        }

        public void OpenDoors()
        {

        }
    }






}
