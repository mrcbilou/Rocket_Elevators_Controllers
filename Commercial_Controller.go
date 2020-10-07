package main

import (
	"fmt"
)

func main() {
	bat := Battery{}
	bat.startBattery(1, 4, 5, 66)
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

func (b *Battery) startBattery(_id int, _columnAmount int, _elevatorPerColumn int, _floorAmount int) {
	b.id = _id

	for i := 0; i < _columnAmount; i++ {
		b.columnList = append(b.columnList, Column{})
		b.columnList[i].startColumn(i+1, _elevatorPerColumn)
	}

	for k := 0; k < _floorAmount; k++ {
		b.callButtonList = append(b.callButtonList, CallButton{k + 1, "Off"})
	}

}

// Column ...
type Column struct {
	id               int
	elevatorList     []Elevator
	bestElevatorCase Elevator
}

// create elevator list
func (c *Column) startColumn(_id int, _elevatorPerColumn int) {
	c.id = _id

	for i := 0; i < _elevatorPerColumn; i++ {
		c.elevatorList = append(c.elevatorList, Elevator{i + 1, "none", 1})
	}
}

//find best elevator
func (c *Column) findBestElevator(_requestedFloor int, _currentDirection string) {
	bestElevatorCase := -1
	distance := 0
	bestDistance := 99

	if _requestedFloor == 1 {

		for i := 0; i <= len(c.elevatorList); i++ {
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
		} else {
			for i := 0; i <= len(c.elevatorList); i++ {
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
			}
		}
	} else {
		for i := 0; i <= len(c.elevatorList); i++ {
			if _currentDirection == "up" && _currentDirection != c.elevatorList[i].direction && _requestedFloor >= c.elevatorList[i].currentFloor {
				distance = c.elevatorList[i].currentFloor - _requestedFloor

				if distance < bestDistance {
					bestDistance = distance
					bestElevatorCase = i
				}
			} else if _currentDirection == "down" && _currentDirection != c.elevatorList[i].direction && _requestedFloor <= c.elevatorList[i].currentFloor {
				distance = _requestedFloor - c.elevatorList[i].currentFloor

				if distance < bestDistance {
					bestDistance = distance
					bestElevatorCase = i
				}
			}
		}
		if bestElevatorCase != -1 {
			fmt.Println("COLUMN FOUND AN ELEVATOR ", bestElevatorCase)
		} else {
			for i := 0; i <= len(c.elevatorList); i++ {
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
			}
		}

	}

}

// Elevator ...
type Elevator struct {
	id           int
	direction    string
	currentFloor int
}

// CallButton ...
type CallButton struct {
	id     int
	status string
}

//FloorIndicator
/* type FloorIndicator struct {

} */

/* func (cb *CallButton) startCallButton(_id int, _floorAmount int ){
	cb.id =_id

	for i := 0; i < _floorAmount; i++{
		cb
	}
} */
