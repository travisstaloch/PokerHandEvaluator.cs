# PokerHandEvaluator.cs 

A port of [HenryRLee/PokerHandEvaluator](https://github.com/HenryRLee/PokerHandEvaluator) from c++ to c#


### Usage

Have a look in the [pheval.Tests](pheval.Tests) folder.  


### Testing

In monodevelop or visual studio, select the pheval.Tests project and choose Run -> 'Run Unit Tests'.  The tests depend on the presence of libpheval.so (or .dll).  This shared object was created as follows:

```console
$ git clone https://github.com/HenryRLee/PokerHandEvaluator
$ cd PokerHandEvaluator/cpp
$ # edit CMakeLists.txt changing STATIC to SHARED on line 16
$ mkdir build && cd build
$ cmake -DBUILD_TESTS=OFF -DBUILD_EXAMPLES=OFF ..
$ make
$ # now copy libpheval.so (or .dll) into the pheval.Tests directory of this project
```

If you're on windows, you'll have to add libpheval.dll to the pheval.Tests project and select 'Copy To Output Directory' (in monodevelop right-click the file -> 'Quick Properties')