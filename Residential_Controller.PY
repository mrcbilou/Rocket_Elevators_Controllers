class Column:
    def __init__(self, floorAmount, elevatorAmount):
     self.floorAmount = floorAmount 
     self.elevatorAmount = elevatorAmount




class Elevator:
    def __init__(self, currentFloor, currentDirection, floorAmount):
     self.currentFloor = currentFloor
     self.currentDirection = currentDirection
     self.floorAmount = floorAmount









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
