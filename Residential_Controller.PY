class Column:
    def __init__(self, floorAmount, elevatorAmount):
     self.floorAmount = floorAmount 
     self.elevatorAmount = elevatorAmount
     

    



class Elevator:
    def __init__(self, currentFloor, currentDirection, floorAmount):
     self.currentFloor = currentFloor
     self.currentDirection = currentDirection
     self.floorAmount = floorAmount



class CallButton:
    def __init__(self, direction, status):
     self.direction = direction
     self.status = status



class FloorButton:
    def __init__(self, floorId, status):
     self.floorId = floorId
     self.status = status







# TEST SECTION

print('COLUMN')

p1 = Column(10, 2)
print(p1.floorAmount)
print(p1.elevatorAmount)

print('ELEVATORS')

q1 = Elevator(2, "idle", 10)
print(q1.currentFloor)
print(q1.currentDirection)
print(q1.floorAmount)

q2 = Elevator(7, "idle", 10)
print(q2.currentFloor)
print(q2.currentDirection)
print(q2.floorAmount)


print('CALL BUTTON')
w1 = CallButton('up , down', "off")
print(w1.direction)
print(w1.status)


print('FLOOR BUTTON')
a1 = FloorButton('1', "off")
print(a1.floorId)
print(a1.status)


#print elevaotr list
elevatorList = (q1, q2)
print(elevatorList)

# floor button loop
floorButtonIter = iter(FloorButton)
for floorAmount in range(9):
    print(next(floorButtonIter))

# call button loop 
for floorAmount in range(9):
    if floorAmount == 0:
        print(CallButton("up","off"))
        print("CallButton","up" , "off")
    if floorAmount == 9:
        print(CallButton("down","off"))
        print("CallButton","down" , "off")
    else:
        print(CallButton("up, down","off"))
        print("CallButton","up, down" , "off")
    

