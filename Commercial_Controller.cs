using System;
using System.Collections.Generic;

namespace Rocket_Elevator_Commercial_Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Battery battery = new Battery(4, 66, 5, -6, 60);

            foreach (Column col in battery.columnList) {

                foreach (Elevator elevator in battery.elevatorList){
                    Console.WriteLine("ELEVATOR Instanced Status");
                    Console.WriteLine(elevator.status);
                }
                Console.WriteLine("Column Instanced");
                Console.WriteLine(col.id);
            }
            Console.WriteLine("Call Button ID AND STATUS");
            foreach (CallButton call_button in battery.callbuttonList){
                Console.WriteLine(call_button.call_button_id);
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
        int battery_maximum_floor;
        public List<Column> columnList = new List<Column>();
        public List<CallButton> callbuttonList = new List<CallButton>();
        public List<Elevator> elevatorList = new List<Elevator>();



        public Battery(int _column_amount, int _floor_amount, int _amount_of_elevator_per_column, int _battery_lowest_floor, int _battery_maximum_floor )
        {
            column_amount = _column_amount;
            number_of_elevators_per_column = _amount_of_elevator_per_column;
            floor_amount = _floor_amount;
            battery_lowest_floor = _battery_lowest_floor;
            battery_maximum_floor = _battery_maximum_floor; 

            for(int i = 1 ; i <= _column_amount; i++){
                Column col = new Column(_floor_amount, _battery_lowest_floor, _floor_amount + _battery_lowest_floor, i);
                columnList.Add(col);
            }

            for(int i = 1; i <= floor_amount; i++){
                CallButton call_button = new CallButton ("off",i);
                callbuttonList.Add(call_button);
            }

            for(int i = 1; i<= _amount_of_elevator_per_column; i++){
                Elevator elevator = new Elevator (i,"on",1,"none");
                elevatorList.Add(elevator);
            }
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
        public string status;
        public int current_floor;
        public string  direction;
        public int id;


        public Elevator (int _id, string _elevator_status, int _elevator_current_floor, string _elevator_direction){
            id = _id;
            status= _elevator_status;
            current_floor = _elevator_current_floor;
            direction= _elevator_direction;
        }
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

    class CallButton {
        public string call_button_status = "off";
        public int call_button_id;
        
        public CallButton(string _call_button_status, int _call_button_id){
            call_button_status = _call_button_status;
            call_button_id = _call_button_id;
        }
      

    }






}
