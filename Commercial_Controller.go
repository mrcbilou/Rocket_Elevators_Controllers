package main

import (
	"fmt"
)

func main() {
	bat := Battery{}
	bat.startBattery(1, 4, 5, 66, -6)
	fmt.Println("Battery ID :", bat.id)
	for i := 0; i < len(bat.columnList); i++ {
		fmt.Println("Column ID :", bat.columnList[i].id)
		for j := 0; j < len(bat.columnList[i].elevatorList); j++ {
			fmt.Println("Elevator ID :", bat.columnList[i].elevatorList[j].id)
		}
	}
	for i := 0; i < len(bat.callButtonList); i++ {
		fmt.Println(bat.callButtonList[i].id, bat.callButtonList[i].status)
	}
	//--------------------TEST SECTION PARAMETERS-------------------------------------
	// ----------SCENARIO 1----------
	bat.columnList[1].elevatorList[0].direction = "down"
	bat.columnList[1].elevatorList[0].currentFloor = 20

	bat.columnList[1].elevatorList[1].direction = "up"
	bat.columnList[1].elevatorList[1].currentFloor = 3

	bat.columnList[1].elevatorList[2].direction = "down"
	bat.columnList[1].elevatorList[2].currentFloor = 13

	bat.columnList[1].elevatorList[3].direction = "down"
	bat.columnList[1].elevatorList[3].currentFloor = 15

	bat.columnList[1].elevatorList[4].direction = "down"
	bat.columnList[1].elevatorList[4].currentFloor = 6
	fmt.Println(" SCENARIO 1")
	bat.columnList[1].requestElevator(1, "up", 20)

	// ----------SCENARIO 2----------
	bat.columnList[2].elevatorList[0].direction = "none"
	bat.columnList[2].elevatorList[0].currentFloor = 1

	bat.columnList[2].elevatorList[1].direction = "up"
	bat.columnList[2].elevatorList[1].currentFloor = 23

	bat.columnList[2].elevatorList[2].direction = "down"
	bat.columnList[2].elevatorList[2].currentFloor = 33

	bat.columnList[2].elevatorList[3].direction = "down"
	bat.columnList[2].elevatorList[3].currentFloor = 40

	bat.columnList[2].elevatorList[4].direction = "down"
	bat.columnList[2].elevatorList[4].currentFloor = 39
	fmt.Println(" SCENARIO 2")
	bat.columnList[2].requestElevator(1, "up", 36)

	// ----------SCENARIO 3----------
	bat.columnList[3].elevatorList[0].direction = "down"
	bat.columnList[3].elevatorList[0].currentFloor = 58

	bat.columnList[3].elevatorList[1].direction = "up"
	bat.columnList[3].elevatorList[1].currentFloor = 50

	bat.columnList[3].elevatorList[2].direction = "up"
	bat.columnList[3].elevatorList[2].currentFloor = 46

	bat.columnList[3].elevatorList[3].direction = "up"
	bat.columnList[3].elevatorList[3].currentFloor = 1

	bat.columnList[3].elevatorList[4].direction = "down"
	bat.columnList[3].elevatorList[4].currentFloor = 60
	fmt.Println(" SCENARIO 3 ")
	bat.columnList[3].requestElevator(54, "down", 1)

	// ----------SCENARIO 4----------
	bat.columnList[0].elevatorList[0].direction = "none"
	bat.columnList[0].elevatorList[0].currentFloor = -4

	bat.columnList[0].elevatorList[1].direction = "none"
	bat.columnList[0].elevatorList[1].currentFloor = 1

	bat.columnList[0].elevatorList[2].direction = "down"
	bat.columnList[0].elevatorList[2].currentFloor = -3

	bat.columnList[0].elevatorList[3].direction = "up"
	bat.columnList[0].elevatorList[3].currentFloor = -6

	bat.columnList[0].elevatorList[4].direction = "down"
	bat.columnList[0].elevatorList[4].currentFloor = -1
	fmt.Println(" SCENARIO 4")
	bat.columnList[0].requestElevator(-3, "up", 1)
}

// Battery ...
type Battery struct {
	id                         int
	columnAmount               int
	numberOfElevatorsPerColumn int
	floorAmount                int
	batteryLowestFloor         int
	batteryMaximumFloor        int
	columnList                 []Column
	callButtonList             []CallButton
}

//creation of a battery
func (b *Battery) startBattery(_id int, _columnAmount int, _elevatorPerColumn int, _floorAmount int, batteryLowestFloor int) {
	b.id = _id
	//creation of a column
	for i := 0; i < _columnAmount; i++ {
		b.columnList = append(b.columnList, Column{})
		b.columnList[i].startColumn(i+1, _elevatorPerColumn)
	}
	//creating call button list
	for i := 1; i <= _floorAmount; i++ {
		j := i + batteryLowestFloor - 1
		if j < 0 {
			b.callButtonList = append(b.callButtonList, CallButton{j, "Off"})
		} else if j >= 0 {
			b.callButtonList = append(b.callButtonList, CallButton{j + 1, "Off"})
		}
	}
}

// Column ...
type Column struct {
	id                 int
	elevatorList       []Elevator
	bestElevatorCase   Elevator
	FloorIndicatorList []FloorIndicator
}

// create elevator list
func (c *Column) startColumn(_id int, _elevatorPerColumn int) {
	c.id = _id

	for i := 0; i < _elevatorPerColumn; i++ {
		c.elevatorList = append(c.elevatorList, Elevator{i + 1, "none", 1, "closed"})
	}
	// floor indicator Creation
	for i := 1; i < len(c.elevatorList); i++ {
		c.FloorIndicatorList = append(c.FloorIndicatorList, FloorIndicator{c.elevatorList[i].currentFloor, "on"})
	}
}

// request elevator function
func (c *Column) requestElevator(_requestedFloor int, _currentDirection string, _userTargetFloor int) {
	c.findBestElevator(_requestedFloor, _currentDirection)
	c.bestElevatorCase.moveElevator(_requestedFloor)
	fmt.Println("ELEVATOR HAS REACHED FLOOR", _requestedFloor)
	c.bestElevatorCase.openDoors("opened")
	fmt.Println("OPENING DOORS....")
	c.bestElevatorCase.openDoors("closed")
	fmt.Println("...CLOSING DOORS")
	c.bestElevatorCase.moveElevator(_userTargetFloor)
	fmt.Println("ELEVATOR HAS REACHED FLOOR", _userTargetFloor)
	c.bestElevatorCase.openDoors("opened")
	fmt.Println("OPENING DOORS....")
	c.bestElevatorCase.openDoors("closed")
	fmt.Println("...CLOSING DOORS")
}

//find best elevator
func (c *Column) findBestElevator(_requestedFloor int, _currentDirection string) {
	bestElevatorCase := -1
	distance := 0
	bestDistance := 99

	if _requestedFloor == 1 {

		for i := 0; i < len(c.elevatorList); i++ {
			if _currentDirection == "up" && _currentDirection != c.elevatorList[i].direction && _requestedFloor <= c.elevatorList[i].currentFloor {
				distance = c.elevatorList[i].currentFloor - _requestedFloor

				if distance < bestDistance {
					bestDistance = distance
					bestElevatorCase = i
				}
			} else if _currentDirection == "down" && _currentDirection != c.elevatorList[i].direction && _requestedFloor >= c.elevatorList[i].currentFloor {
				distance = _requestedFloor - c.elevatorList[i].currentFloor

				if distance < bestDistance {
					bestDistance = distance
					bestElevatorCase = i
				}
			}
		}
		if bestElevatorCase != -1 {
			fmt.Println("COLUMN FOUND AN ELEVATOR ", bestElevatorCase)
			fmt.Println("this is the best 1")
		} else {
			for i := 0; i < len(c.elevatorList); i++ {
				if _currentDirection == "none" {
					distance = c.elevatorList[i].currentFloor - _requestedFloor

					if distance < bestDistance {
						bestDistance = distance
						bestElevatorCase = i
					}
				}
			}
			if bestElevatorCase != -1 {
				fmt.Println("COLUMN FOUND AN ELEVATOR ", bestElevatorCase)
				fmt.Println("this is the best 2")
			}
		}
	} else {
		for i := 0; i < len(c.elevatorList); i++ {
			if _currentDirection == "up" && _currentDirection == c.elevatorList[i].direction && _requestedFloor >= c.elevatorList[i].currentFloor {
				distance = _requestedFloor - c.elevatorList[i].currentFloor

				if distance < bestDistance {
					bestDistance = distance
					bestElevatorCase = i
				}
			} else if _currentDirection == "down" && _currentDirection == c.elevatorList[i].direction && _requestedFloor <= c.elevatorList[i].currentFloor {
				distance = c.elevatorList[i].currentFloor - _requestedFloor

				if distance < bestDistance {
					bestDistance = distance
					bestElevatorCase = i
				}
			}
		}
		if bestElevatorCase != -1 {
			fmt.Println("COLUMN FOUND AN ELEVATOR ", bestElevatorCase)
			fmt.Println("this is the best 3")
		} else {
			for i := 0; i < len(c.elevatorList); i++ {
				if _currentDirection == "none" {
					distance = c.elevatorList[i].currentFloor - _requestedFloor

					if distance < bestDistance {
						bestDistance = distance
						bestElevatorCase = i
					}
				}
			}
			if bestElevatorCase != -1 {
				fmt.Println("COLUMN FOUND AN ELEVATOR ", bestElevatorCase)
				fmt.Println("this is the best 4")
			}
		}

	}

}

// Elevator ...
type Elevator struct {
	id           int
	direction    string
	currentFloor int
	doorStatus   string
}

//move Elevator function

func (e *Elevator) moveElevator(_userTargetFloor int) {
	_userTargetFloor = e.currentFloor
}

// openDoors function
func (e *Elevator) openDoors(doorStatus string) {
	doorStatus = e.doorStatus
}

// CallButton ...
type CallButton struct {
	id     int
	status string
}

// FloorIndicator ...
type FloorIndicator struct {
	elevatorCurrentFloor int
	floorIndicatorStatus string
}
