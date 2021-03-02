cmake_minimum_required(VERSION 3.19.6)
project(rssnapshot VERSION 0.1.0)
set(CMAKE_CXX_STANDARD 17)



macro(print_all_variables)
    message(STATUS "print_all_variables------------------------------------------{")
    get_cmake_property(_variableNames VARIABLES)
    foreach (_variableName ${_variableNames})
        message(STATUS "${_variableName}=${${_variableName}}")
    endforeach()
    message(STATUS "print_all_variables------------------------------------------}")
endmacro()

#set(CMAKE_VERBOSE_MAKEFILE ON CACHE BOOL "TRUE")
#set(CMAKE_VERBOSE_MAKEFILE  "TRUE")
#set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wall -Werror -std=c++17")

#set(SOURCE_FILE tinyxml2.cpp)
#add_library(tinyxml2 ${SOURCE_FILES})

file(GLOB SOURCES "src/*.cpp")

message(STATUS "CMAKE_CURRENT_LIST_DIR=${CMAKE_CURRENT_LIST_DIR}")
set(CMAKE_BASE_DIR ${CMAKE_CURRENT_LIST_DIR})
message(STATUS "CMAKE_BASE_DIR=${CMAKE_BASE_DIR}")

list(APPEND CMAKE_MODULE_PATH "${CMAKE_CURRENT_LIST_DIR}/cmake")
add_executable(rssnapshot ${SOURCES})

include(FindPkgConfig)
find_package(cryptopp REQUIRED)


message(STATUS "CRYPTOPP_INCLUDE_DIR=${CRYPTOPP_INCLUDE_DIR}")

message(STATUS "CRYPTOPP_LIBRARY=${CRYPTOPP_LIBRARY}")

include_directories(${CRYPTOPP_INCLUDE_DIR})
target_link_libraries(${PROJECT_NAME} ${CRYPTOPP_LIBRARY})


set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)

 
 #print_all_variables()


