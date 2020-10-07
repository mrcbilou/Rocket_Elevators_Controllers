package main

import "fmt"

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

func (b *Battery) startBattery(_id int, __columnAmount int, _elevatorPerColumn int, _floorAmount int) {
	b.id = _id

	for i := 0; i < __columnAmount; i++ {
		b.columnList = append(b.columnList, Column{})
		b.columnList[i].startColumn(i+1, _elevatorPerColumn)
	}

	for k := 0; k < _floorAmount; k++ {
		b.callButtonList = append(b.callButtonList, CallButton{k + 1, "Off"})
	}

}

// Column ...
type Column struct {
	id           int
	elevatorList []Elevator
}

func (c *Column) startColumn(_id int, _elevatorPerColumn int) {
	c.id = _id

	for i := 0; i < _elevatorPerColumn; i++ {
		c.elevatorList = append(c.elevatorList, Elevator{i + 1})
	}

}

// Elevator ...
type Elevator struct {
	id int
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
