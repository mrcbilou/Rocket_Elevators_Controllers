using System;
using System.Collections.Generic;

namespace Rocket_Elevator_Commercial_Controller
{
    
    public class Battery
    {
        // member variables
        int column_amount;
        int number_of_elevators_per_column;
        int floor_amount;
        int battery_lowest_floor;
        int battery_maximum_floor;
        public List<List<int>> deservedFloors = new List<List<int>>();

        public List<Column> columnList = new List<Column>();
        public List<CallButton> callbuttonList = new List<CallButton>();
        public Column bestColumnCase = null;
    
        public Battery(int _column_amount, int _floor_amount, int _amount_of_elevator_per_column, int _battery_lowest_floor, int _battery_maximum_floor )
        {
            column_amount = _column_amount;
            number_of_elevators_per_column = _amount_of_elevator_per_column;
            floor_amount = _floor_amount;
            battery_lowest_floor = _battery_lowest_floor;
            battery_maximum_floor = _battery_maximum_floor;
            
            // create column list
            for(int i = 1 ; i <= _column_amount; i++)
            {
                Column col = new Column(_floor_amount, i, _amount_of_elevator_per_column);
                columnList.Add(col);
            }
            //create call button list
            for(int i = 1; i <= floor_amount; i++)
            {
                int j = i + _battery_lowest_floor - 1 ;
                if (j < 0)
                {
                    CallButton call_button = new CallButton ("off", j);
                    callbuttonList.Add(call_button);
                }
                
                else if (j >= 0)
                {
                    CallButton call_button = new CallButton ("off", j + 1);
                    callbuttonList.Add(call_button);
                }
            }

        // columnList[0].findBestElevator("fgg", 6, 34);
        }

        public void findBestColumn(int _requested_floor, int elevator_current_floor, string _current_direction)
        {
            foreach (Column col in columnList)
            {
                if (_requested_floor >= col.minimum_floor && _requested_floor <= col.maximum_floor)
                {
                    col.findBestElevator(_requested_floor, _current_direction, elevator_current_floor);
                }
            }
        }
        
        public void requestElevator()
        {

        }

    }

    public class Column
    {
        public int id;
        public int floor_amount;
        public int minimum_floor;
        public int maximum_floor;
        public int amount_of_elevator_per_column;
        public List<Elevator> elevatorList = new List<Elevator>();
        public List<FloorIndicator> floorIndicatorList = new List<FloorIndicator>();
        public Elevator bestElevatorCase = null;

        
        public Column (int _floor_amount, int _id ,int _amount_of_elevator_per_column) {
            id = _id;
            floor_amount = _floor_amount;
            amount_of_elevator_per_column =_amount_of_elevator_per_column;
            
            // create elevator list
            for(int i = 1; i<= amount_of_elevator_per_column; i++){
                Elevator elevator = new Elevator (i,"on",1,"none");
                elevatorList.Add(elevator);
            }
            for(int i = 0; i < elevatorList.Count; i++){
                FloorIndicator floor_indicator = new FloorIndicator(elevatorList[i].current_floor, "on");
                Console.WriteLine("FLOOR INDICATOR CREATED : {0}",i +1);
                floorIndicatorList.Add(floor_indicator);
            }
        }

        public void changeRange(int _ground_floor,int _min, int _max)
        {   
            _ground_floor = 1;
            minimum_floor = _min;
            maximum_floor = _max;
        }

        //----------------------------------------------//  
            // REVIEW FIND BEST ELEVATOR                    
        //----------------------------------------------//  

        public void findBestElevator(int _requested_floor, string _current_direction, int _elevator_current_floor)
        {
            int distance = 0;
            int bestDistance = 99;

            if (_requested_floor == 1)
            {
                foreach (Elevator elevator in elevatorList)
                {
                    if (_current_direction == "up" && _current_direction != elevator.direction && _requested_floor <= _elevator_current_floor)
                    {
                        distance = Math.Abs(_elevator_current_floor - _requested_floor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevatorCase = elevator;
                        }
                    }
                    
                    else if (_current_direction == "down" && _current_direction != elevator.direction && _requested_floor >= _elevator_current_floor)
                    {
                        distance = Math.Abs(_elevator_current_floor - _requested_floor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevatorCase = elevator;
                        }   
                    }
                }

                if (bestElevatorCase != null)
                {
                    Console.WriteLine("COLUMN FOUND AN ELEVATOR {0}", bestElevatorCase.id);
                    // Console.WriteLine(bestElevatorCase);
                    Console.WriteLine("this is the best 1");
                }

                else 
                {
                    foreach (Elevator elevator in elevatorList)
                    {
                        if(_current_direction == "none")
                        {
                            distance = Math.Abs(_elevator_current_floor - _requested_floor);
                            
                            if (distance < bestDistance)
                            {
                                bestDistance = distance;
                                bestElevatorCase = elevator ;
                            }
                        }
                    }

                    if (bestElevatorCase != null)
                    {
                        Console.WriteLine("COLUMN FOUND AN ELEVATOR");
                        Console.WriteLine(bestElevatorCase);
                        Console.WriteLine("this is the best 2");
                    }
                }
                
            } 
            else 
            {
                foreach (Elevator elevator in elevatorList)
                {
                    if (_current_direction == "up" && _current_direction == elevator.direction && _requested_floor <= _elevator_current_floor)
                    {
                        distance = Math.Abs(_elevator_current_floor - _requested_floor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevatorCase = elevator;
                        }
                    }
                    
                    else if (_current_direction == "down" && _current_direction == elevator.direction && _requested_floor >= _elevator_current_floor)
                    {
                        distance = Math.Abs(_elevator_current_floor - _requested_floor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevatorCase = elevator;
                        }   
                    }
                }

                if (bestElevatorCase != null)
                {
                    Console.WriteLine("COLUMN FOUND AN ELEVATOR");
                    Console.WriteLine(bestElevatorCase);
                    Console.WriteLine("this is the best 3");
                }

                else 
                {
                    foreach (Elevator elevator in elevatorList)
                    {
                        if(_current_direction == "none")
                        {
                            distance = Math.Abs(_elevator_current_floor - _requested_floor);
                            
                            if (distance < bestDistance)
                            {
                                bestDistance = distance;
                                bestElevatorCase = elevator ;
                            }
                        }
                    }

                    if (bestElevatorCase != null)
                    {
                        Console.WriteLine("COLUMN FOUND AN ELEVATOR");
                        Console.WriteLine(bestElevatorCase);
                        Console.WriteLine("this is the best 4");
                    }
                }
            }
        }
    }

    public class Elevator
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

        public void moveElevator()
        {

        }

        public void openDoors()
        {

        }
    }

    public class CallButton {
        public string call_button_status = "off";
        public int call_button_id;
        
        public CallButton(string _call_button_status, int _call_button_id){
            call_button_status = _call_button_status;
            call_button_id = _call_button_id;
        }
    

    }

    public class RequestFloorButton
    {
        public string request_floor_button_status ="off";
        public int request_floor_button_id;

        public RequestFloorButton(string _request_floor_button_status, int _request_floor_button_id)
        {
            request_floor_button_status = _request_floor_button_status;
            request_floor_button_id = _request_floor_button_id;
        }
    }

    public class FloorIndicator
    {
        public int elevator_current_floor;
        public string floor_indicator_status = "on";
        public FloorIndicator(int _elevator_current_floor, string _floor_indicator_status)
        {
            elevator_current_floor =_elevator_current_floor;
            floor_indicator_status = _floor_indicator_status;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Battery battery = new Battery(4, 66, 5, -6, 60);

            foreach (Column col in battery.columnList) 
            {
                Console.WriteLine("Column Instanced : {0} ",col.id);
                    foreach (Elevator elevator in col.elevatorList)
                    {
                        Console.WriteLine("ELEVATOR Instanced Status : {0} ", elevator.status);  
                    }
            }

            battery.columnList[0].changeRange(1,-6, -1);
            battery.columnList[1].changeRange(1, 2, 20);
            battery.columnList[2].changeRange(1, 21, 40);
            battery.columnList[3].changeRange(1, 41, 60); 

            battery.columnList[1].elevatorList[0].direction = "down";
            battery.columnList[1].elevatorList[0].current_floor = 20;

            battery.columnList[1].elevatorList[1].direction = "up";
            battery.columnList[1].elevatorList[1].current_floor = 3;

            battery.columnList[1].elevatorList[2].direction = "down";
            battery.columnList[1].elevatorList[2].current_floor = 13;

            battery.columnList[1].elevatorList[3].direction = "down";
            battery.columnList[1].elevatorList[3].current_floor = 15;

            battery.columnList[1].elevatorList[4].direction = "down";
            battery.columnList[1].elevatorList[4].current_floor = 6;

            battery.columnList[1].findBestElevator(1, "up", 6);

            Console.WriteLine("Call Button ID AND STATUS");
            foreach (CallButton call_button in battery.callbuttonList)
            { 
                Console.WriteLine("{0},{1}",call_button.call_button_id,call_button.call_button_status);
            }
            
            //battery.findColumn("g", 5, 5); => { ... bestColumn.findBestElevator("g", 5, 5) } 
        }
    }
}