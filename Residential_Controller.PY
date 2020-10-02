class Column:
    def __init__(self, floorAmount, elevatorAmount):
        self.floorAmount = floorAmount 
        self.elevatorAmount = elevatorAmount
        self.floorList = []
        self.elevatorList = []
        self.callButtonList = []
        self.floorButtonList = []
        

        i = 1
        while i <= self.elevatorAmount:
            #print('NEW ELEVATORS')
            elevator = Elevator(1, i)
            self.elevatorList.append(elevator)
            i += 1

        # print(self.elevatorList)

        for floorAmount in range(1,11):
            #print(floorAmount)
            floorButton = FloorButton (floorAmount, 'off')
            self.floorButtonList.append(floorButton)

        # print(self.floorButtonList)

        for floorAmount in range(1, 11):
            #print(floorAmount)
            floor = Floor (floorAmount)
            self.floorList.append(floor)

        # print(self.floorButtonList)

        for floor in range(len(self.floorList)):
            #print("UN bon Burdog")
            if floor == 0: 
                #print('les jumelles mc cormick')
                callButton = CallButton ('up', 'off')
                self.callButtonList.append(callButton)
            elif floor == 9:
                #print('le commandant picard')
                callButton = CallButton ('down', 'off')
                self.callButtonList.append(callButton)
            else:
                #print('une grenade avec sa')
                callButton = CallButton ('up , down', 'off')
                self.callButtonList.append(callButton)

        # print(self.callButtonList)

    def RequestElevator(self, RequestedFloor, Direction):
        bestDistance = 99
        bestElevatorCase = 0
        print("request!!")
        
        for i in range(len(self.elevatorList)):
            if bestElevatorCase == 0:
                bestElevatorCase = self.elevatorList[i]

            if Direction == 'up' and self.elevatorList[i].currentDirection == 'up' and self.elevatorList[i].currentFloor <= RequestedFloor:
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                if distance < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]

            elif Direction == 'down' and self.elevatorList[i].currentDirection == 'down' and self.elevatorList[i].currentFloor >= RequestedFloor:
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                if distance < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]

            elif self.elevatorList[i].status == 'idle':
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                if distance < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]

            else:
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                if distance + self.floorAmount < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]

        return bestElevatorCase
    

    def RequestFloor (self, elevator,requestedFloor):
        elevator.moveElevator(requestedFloor)
        print('FLOOR SELECTED...     MOVING TO FLOOR' )
        print(requestedFloor)

class Elevator:
    def __init__(self, currentFloor, _id):
        self.id = _id
        self.currentFloor = currentFloor
        self.currentDirection = "stop"
        self.status = 'idle'

    def moveElevator (self,targetFloor):
        self.currentFloor = targetFloor

class CallButton:
    def __init__(self, direction, status):
        self.direction = direction
        self.status = status

class FloorButton:
    def __init__(self, floorId, status):
        self.floorId = floorId
        self.status = status

class Floor:
    def __init__(self, floorId):
        self.floorId = floorId





# TEST SECTION

#print('COLUMN')
columntTest1= Column(10,2)

print("Floor Amount :", columntTest1.floorAmount, "|", "Elevator Amount", columntTest1.elevatorAmount)




columntTest1.elevatorList[0].currentDirection = "stop"
columntTest1.elevatorList[0].currentFloor = 2
columntTest1.elevatorList[0].status = "idle"
columntTest1.elevatorList[1].currentDirection = "stop"
columntTest1.elevatorList[1].currentFloor = 6
columntTest1.elevatorList[1].status = "idle"

requestTest1 = columntTest1.RequestElevator(3, "up")
columntTest1.RequestFloor(requestTest1, 7)
print(requestTest1.id)


''' q1 = Elevator(2, "idle", 'A')
print(q1.currentFloor)
print(q1.currentDirection) '''


floor = Floor(1)

floorButton = FloorButton (1,'off')

''' print('CALL BUTTON')
w1 = CallButton('up , down', "off")
print(w1.direction)
print(w1.status) '''


''' print('FLOOR BUTTON')
a1 = FloorButton('1', "off")
print(a1.floorId)
print(a1.status) '''


# floor button loop
#floorButtonIter = iter(FloorButton)
#for floorAmount in range(9):
 #   print(next(floorButtonIter))

# call button loop 
#for floorAmount in range(9):
 #   if floorAmount == 0:
  #      print(CallButton("up","off"))
   #     print("CallButton","up" , "off")
    #if floorAmount == 9:
     #   print(CallButton("down","off"))
      #  print("CallButton","down" , "off")
   # else:
    #    print(CallButton("up, down","off"))
     #   print("CallButton","up, down" , "off")