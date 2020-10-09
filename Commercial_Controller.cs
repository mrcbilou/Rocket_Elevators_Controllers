/* /***********************************************************************;
* Project           : Commercial_Controller
*
* Program name      : Commercial_Controller.cs
*
* Author            : Louis-Felix Beland
*
* Date created      : 9 October 2020
*
* Purpose           : Programming an algorithm for a Commercial Elevator Controller
*
|**********************************************************************/ 

using System;
using System.Collections.Generic;

namespace Rocket_Elevator_Commercial_Controller
{
    
    public class Battery // This is the definition of the Battery Object
    {
        // member variables
        int column_amount;
        int number_of_elevators_per_column;
        int floor_amount;
        int battery_lowest_floor;
        int battery_maximum_floor;
        public Column bestColumnCase;
        public List<List<int>> deservedFloors = new List<List<int>>();

        public List<Column> columnList = new List<Column>();
        public List<CallButton> callbuttonList = new List<CallButton>();
        
        // This is the Constructor of the BATTERY object 
        public Battery(int _column_amount, int _floor_amount, int _amount_of_elevator_per_column, int _battery_lowest_floor, int _battery_maximum_floor )
        {
            column_amount = _column_amount;
            number_of_elevators_per_column = _amount_of_elevator_per_column;
            floor_amount = _floor_amount;
            battery_lowest_floor = _battery_lowest_floor;
            battery_maximum_floor = _battery_maximum_floor;
            
            // this function will create the column list
            for(int i = 1 ; i <= _column_amount; i++)
            {
                Column col = new Column(_floor_amount, i, _amount_of_elevator_per_column);
                columnList.Add(col);
            }
            //this function will create the  call button list
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
        }
        // this is the function that will Find the best column for the user
        public void findBestColumn(int _requested_floor, string _current_direction, int user_target_floor)
        {
            if (_requested_floor != 1) // if the requested floor is not RC the request elevator function is applied
            {
                foreach (Column col in columnList)
                {
                    if (_requested_floor >= col.minimum_floor && _requested_floor <= col.maximum_floor)
                    {
                        bestColumnCase = col ;
                        col.requestElevator( _requested_floor,  _current_direction,user_target_floor);
                    }    
                }    
            }
            else // Otherwise if you are at RC a column and elevator will be assigned to the user when the request is made
            {
                foreach (Column col in columnList)
                {
                    if (user_target_floor >= col.minimum_floor && user_target_floor <= col.maximum_floor)
                    {
                        bestColumnCase = col ;
                        col.assingElevator( _requested_floor,  _current_direction, user_target_floor);
                    } 
                }
            }
            Console.WriteLine("The Best Column For You Is {0}  ", bestColumnCase.id );
        } 
    }

    public class Column   // This is the definition of the Column Object
    {
        public int id;
        public int floor_amount;
        public int minimum_floor;
        public int maximum_floor;
        public int amount_of_elevator_per_column;
        public List<Elevator> elevatorList = new List<Elevator>();
        public List<FloorIndicator> floorIndicatorList = new List<FloorIndicator>();
        public Elevator bestElevatorCase = null;

        // This is the Constructor function off the COLUMN object
        public Column (int _floor_amount, int _id ,int _amount_of_elevator_per_column) {
            id = _id;
            floor_amount = _floor_amount;
            amount_of_elevator_per_column =_amount_of_elevator_per_column;
            
            // this will create the elevator list
            for(int i = 1; i<= amount_of_elevator_per_column; i++){
                Elevator elevator = new Elevator (i,"on",1,"none","closed");
                elevatorList.Add(elevator);
            }
            for(int i = 0; i < elevatorList.Count; i++){
                FloorIndicator floor_indicator = new FloorIndicator(elevatorList[i].current_floor, "on");
                //Console.WriteLine("FLOOR INDICATOR CREATED : {0}",i +1);
                floorIndicatorList.Add(floor_indicator);
            }
        }
        // this function will assign a dedicated RANGE to a particular Column
        public void changeRange(int _ground_floor,int _min, int _max)
        {   
            _ground_floor = 1;
            minimum_floor = _min;
            maximum_floor = _max;
        }
        
        //  this function will make the elevator move based on the request made by the user
         public void requestElevator(int _requested_floor, string  _current_direction, int user_target_floor )
        {  
            findBestElevator(_requested_floor, _current_direction);
            bestElevatorCase.moveElevator(_requested_floor);
            Console.WriteLine("Elevator Has Reached FLoor : {0} ",_requested_floor);
            bestElevatorCase.openDoors("opened");
            Console.WriteLine("Opening Doors");
            bestElevatorCase.openDoors("closed");
            Console.WriteLine("Closing Doors");
            bestElevatorCase.moveElevator(user_target_floor);
            Console.WriteLine("Elevator Has Reached FLoor : {0} ",user_target_floor);
            Console.WriteLine("Opening Doors");
            bestElevatorCase.openDoors("opened");
            Console.WriteLine("Closing Doors");
            bestElevatorCase.openDoors("closed");
        }
        //  this function will assign an elevator and make it move based on the request made by the user
        public void assingElevator(int _requested_floor, string  _current_direction, int user_target_floor )
        {  
            findBestElevator(_requested_floor, _current_direction);
            Console.WriteLine("YOU HAVE BEEN ASSIGNED ELEVATOR NUMBER : {0}", bestElevatorCase.id);
            bestElevatorCase.moveElevator(_requested_floor);
            Console.WriteLine("ELEVATOR WILL PICK YOU UP AT RC");
            bestElevatorCase.openDoors("opened");
            Console.WriteLine("Opening Doors");
            bestElevatorCase.openDoors("closed");
            Console.WriteLine("Closing Doors");
            bestElevatorCase.moveElevator(user_target_floor);
            Console.WriteLine("Elevator Has Reached FLoor : {0} ",user_target_floor);
            Console.WriteLine("Opening Doors");
            bestElevatorCase.openDoors("opened");
            Console.WriteLine("Closing Doors");
            bestElevatorCase.openDoors("closed");
        }
        
        // this function will find the best elevator based on the current requested floor and the direction of the elevator
        public void findBestElevator(int _requested_floor, string _current_direction)
        {
            int distance = 0;
            int bestDistance = 99;

            if (_requested_floor == 1)   // if the requested floor is RC the function will retun an elevator object based on the previous parameters
            {
                foreach (Elevator elevator in elevatorList)
                {
                    if (_current_direction == "up" && _current_direction != elevator.direction && _requested_floor <= elevator.current_floor)
                    {
                        distance = Math.Abs(elevator.current_floor - _requested_floor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevatorCase = elevator;
                        }
                    }
                    
                    else if (_current_direction == "down" && _current_direction != elevator.direction && _requested_floor >= elevator.current_floor)
                    {
                        distance = Math.Abs(elevator.current_floor - _requested_floor);

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
                    //Console.WriteLine("this is the best 1");
                }

                else 
                {
                    foreach (Elevator elevator in elevatorList)
                    {
                        if(_current_direction == "none")
                        {
                            distance = Math.Abs(elevator.current_floor - _requested_floor);
                            
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
                       // Console.WriteLine(bestElevatorCase);
                       // Console.WriteLine("this is the best 2");
                    }
                }
                
            } 
            else // OTHERWISE the function will return an ELEVATOR object based on the same previous parameters but inverted on the direction for better priority
            {
                foreach (Elevator elevator in elevatorList)
                {
                    if (_current_direction == "up" && _current_direction == elevator.direction && _requested_floor >= elevator.current_floor)
                    {
                        distance = Math.Abs(elevator.current_floor - _requested_floor);

                        if (distance < bestDistance)
                        {
                            bestDistance = distance;
                            bestElevatorCase = elevator;
                        }
                    }
                    
                    else if (_current_direction == "down" && _current_direction == elevator.direction && _requested_floor <= elevator.current_floor)
                    {
                        distance = Math.Abs(elevator.current_floor - _requested_floor);

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
                    //Console.WriteLine(bestElevatorCase);
                    //Console.WriteLine("this is the best 3");
                }

                else 
                {
                    foreach (Elevator elevator in elevatorList)
                    {
                        if(_current_direction == "none")
                        {
                            distance = Math.Abs(elevator.current_floor - _requested_floor);
                            
                            if (distance < bestDistance)
                            {
                                bestDistance = distance;
                                bestElevatorCase = elevator ;
                            }
                        }
                    }

                    if (bestElevatorCase != null)
                    {
                        Console.WriteLine("COLUMN FOUND AN ELEVATOR {0}", bestElevatorCase.id);
                        //Console.WriteLine(bestElevatorCase);
                        //Console.WriteLine("this is the best 4");
                    }
                }
            }
        }
    }

    public class Elevator  // This is the definition of the Elevator Object
    {
        public string status;
        public int current_floor;
        public string  direction;
        public int id;
        public string door_status;

        // this is the constructor function of the ELEVATOR object
        public Elevator (int _id, string _elevator_status, int _elevator_current_floor, string _elevator_direction, string _door_status){
            id = _id;
            status= _elevator_status;
            current_floor = _elevator_current_floor;
            direction= _elevator_direction;
            door_status= _door_status;
        }

        // this is the function that moves Elevator it is called on the requestElevator and the assignElevator functions
        public void moveElevator(int _target_floor)
        {
            current_floor= _target_floor;
        }

        // this is the function that open the doors on the elevator it is called on the requestElevator and the assignElevator functions
        public void openDoors(string door_status)
        {
            status= door_status;
        }
    }

    public class CallButton   // This is the definition of the CallButton Object
    {
        public string call_button_status = "off";
        public int call_button_id;
        
        // this is the constructor function for the CAll button object
        public CallButton(string _call_button_status, int _call_button_id){
            call_button_status = _call_button_status;
            call_button_id = _call_button_id;
        }
    }

    public class RequestFloorButton    // This is the definition of the RequestFloorButton Object
    {
        public string request_floor_button_status ="off";
        public int request_floor_button_id;
        // this is the constructor function for the request button object
        public RequestFloorButton(string _request_floor_button_status, int _request_floor_button_id)
        {
            request_floor_button_status = _request_floor_button_status;
            request_floor_button_id = _request_floor_button_id;
        }
    }

    public class FloorIndicator     // This is the definition of the FloorIndicator Object
    {
        public int elevator_current_floor;
        public string floor_indicator_status = "on";

        // this is the constructor function for the Floor indicator object
        public FloorIndicator(int _elevator_current_floor, string _floor_indicator_status)
        {
            elevator_current_floor =_elevator_current_floor;
            floor_indicator_status = _floor_indicator_status;
        }

    }

    class Program    //// This is the Main program that will be ran on execution
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Battery battery = new Battery(4, 66, 5, -6, 60);

            /*foreach (Column col in battery.columnList) 
            {
                Console.WriteLine("Column Instanced : {0} ",col.id);
                    foreach (Elevator elevator in col.elevatorList)
                    {
                        Console.WriteLine("ELEVATOR Instanced Status : {0} ", elevator.status);  
                    }
            }*/

            battery.columnList[0].changeRange(1,-6, 1);
            battery.columnList[1].changeRange(1, 2, 20);
            battery.columnList[2].changeRange(1, 21, 40);
            battery.columnList[3].changeRange(1, 41, 60); 

            // SCENARIO 1
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

            Console.WriteLine("\n SCENARIO 1 \n");
            battery.findBestColumn(1, "up", 20 );
            //battery.columnList[1].requestElevator(1, "up", 20 );

            // SCENARIO 2
            battery.columnList[2].elevatorList[0].direction = "none";
            battery.columnList[2].elevatorList[0].current_floor = 1;

            battery.columnList[2].elevatorList[1].direction = "up";
            battery.columnList[2].elevatorList[1].current_floor = 23;

            battery.columnList[2].elevatorList[2].direction = "down";
            battery.columnList[2].elevatorList[2].current_floor = 33;

            battery.columnList[2].elevatorList[3].direction = "down";
            battery.columnList[2].elevatorList[3].current_floor = 40;

            battery.columnList[2].elevatorList[4].direction = "down";
            battery.columnList[2].elevatorList[4].current_floor = 39;

            Console.WriteLine("\n SCENARIO 2 \n");
            battery.findBestColumn(1, "up", 36  );
           // battery.columnList[2].requestElevator(1, "up", 36 );

            // SCENARIO 3
            battery.columnList[3].elevatorList[0].direction = "down";
            battery.columnList[3].elevatorList[0].current_floor = 58;

            battery.columnList[3].elevatorList[1].direction = "up";
            battery.columnList[3].elevatorList[1].current_floor = 50;

            battery.columnList[3].elevatorList[2].direction = "up";
            battery.columnList[3].elevatorList[2].current_floor = 46;

            battery.columnList[3].elevatorList[3].direction = "up";
            battery.columnList[3].elevatorList[3].current_floor = 1;

            battery.columnList[3].elevatorList[4].direction = "down";
            battery.columnList[3].elevatorList[4].current_floor = 60;

            Console.WriteLine("\n SCENARIO 3 \n");
            battery.findBestColumn(54, "down", 1);
            //battery.columnList[3].requestElevator(54, "down", 1 );

            // SCENARIO 4
            battery.columnList[0].elevatorList[0].direction = "none";
            battery.columnList[0].elevatorList[0].current_floor = -4;

            battery.columnList[0].elevatorList[1].direction = "none";
            battery.columnList[0].elevatorList[1].current_floor = 1;

            battery.columnList[0].elevatorList[2].direction = "down";
            battery.columnList[0].elevatorList[2].current_floor = -3;

            battery.columnList[0].elevatorList[3].direction = "up";
            battery.columnList[0].elevatorList[3].current_floor = -6;

            battery.columnList[0].elevatorList[4].direction = "down";
            battery.columnList[0].elevatorList[4].current_floor = -1;

            Console.WriteLine("\n SCENARIO 4 \n");
            battery.findBestColumn(-3, "up", 1);
           // battery.columnList[0].requestElevator(-3, "up", 1 );

            //Console.WriteLine("Call Button ID AND STATUS");
            /*foreach (CallButton call_button in battery.callbuttonList)
            { 
                //Console.WriteLine("{0},{1}",call_button.call_button_id,call_button.call_button_status);
            }*/
            //battery.findColumn("g", 5, 5); => { ... bestColumn.findBestElevator("g", 5, 5) } 
        }
    }
}