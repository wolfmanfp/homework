cmake_minimum_required(VERSION 2.8.3)
project(roscar_control)

find_package(catkin REQUIRED COMPONENTS roscpp std_msgs)

## Declare a catkin package
catkin_package()

include_directories(include ${catkin_INCLUDE_DIRS})

add_executable(car_teleop_key src/car_teleop_key.cpp)
target_link_libraries(car_teleop_key ${catkin_LIBRARIES})
