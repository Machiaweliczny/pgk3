COMPILER=g++
CFLAGS=-std=c++11 -I/home/anl/include/ -I/home/anl/include/GLFW/ -I/usr/include -I/usr/local/include
MAC_FRAMEWORKS=-framework Cocoa -framework IOKit -framework CoreVideo -framework OpenGL
LIBS=-lglfw3 -lGLEW -lpthread ${MAC_FRAMEWORKS}
#linux: -lGl -lGLU -lX11 -lXxf86vm -lXrandr -lXi
DO_SKOMPILOWANIA=main.o ./common/shader.o
DO_ZLINKOWNIA=main.o shader.o

default: show

# (*) How to compile cpp files
.cpp.o:
	${COMPILER} -c ${CFLAGS} $<
# Our main(default) taks when running "make"
# DO_SKOMPILOWANIA are cpp files passed as dependencies - compiled with (*) rule
show: ${DO_SKOMPILOWANIA}
	${COMPILER} -L/home/anl/libs/ ${DO_ZLINKOWNIA} -o show  ${COMMON} ${LIBS}
# This clean object files and executable with "make clean"
clean:
	rm *o show
