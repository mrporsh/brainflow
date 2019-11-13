﻿using System;
using Accord.Math;


namespace brainflow
{

    /// <summary>
    /// BoardShim class to communicate with a board
    /// </summary>
    public class BoardShim
    {
        /// <summary>
        /// BrainFlow's board id
        /// </summary>
        public int board_id;
        private string input_json;

        /// <summary>
        /// Create an instance of BoardShim class
        /// </summary>
        /// <param name="board_id"></param>
        /// <param name="input_params"></param>
        public BoardShim (int board_id, BrainFlowInputParams input_params)
        {
            this.board_id = board_id;
            this.input_json = input_params.to_json ();
        }

        /// <summary>
        /// get sampling rate for this board id
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>sampling rate</returns>
        public static int get_sampling_rate (int board_id)
        {
            int[] val = new int[1];
            int res = BoardControllerLibrary.get_sampling_rate (board_id, val);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return val[0];
        }

        /// <summary>
        /// get row index in returned by get_board_data() 2d array which hold package nums
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>row num in 2d array</returns>
        public static int get_package_num_channel (int board_id)
        {
            int[] val = new int[1];
            int res = BoardControllerLibrary.get_package_num_channel (board_id, val);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return val[0];
        }

        /// <summary>
        /// get row index which hold timestamps
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>row num in 2d array</returns>
        public static int get_timestamp_channel (int board_id)
        {
            int[] val = new int[1];
            int res = BoardControllerLibrary.get_timestamp_channel (board_id, val);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return val[0];
        }

        /// <summary>
        /// get number of rows in returned by get_board_data() 2d array 
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>number of rows in 2d array</returns>
        public static int get_num_rows (int board_id)
        {
            int[] val = new int[1];
            int res = BoardControllerLibrary.get_num_rows (board_id, val);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return val[0];
        }

        /// <summary>
        /// get row indices of EEG channels for this board, for some board we can not split EMG\EEG\.. data and return the same array for all of them
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_eeg_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_eeg_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indices of EMG channels for this board, for some board we can not split EMG\EEG\.. data and return the same array for all of them
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_emg_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_emg_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indices of ECG channels for this board, for some board we can not split EMG\EEG\.. data and return the same array for all of them
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_ecg_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_ecg_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indices of EOG channels for this board, for some board we can not split EMG\EEG\.. data and return the same array for all of them
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_eog_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_eog_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indices of EDA channels for this board, for some board we can not split EMG\EEG\.. data and return the same array for all of them
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_eda_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_eda_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indeces which hold ppg data
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_ppg_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_ppg_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indices which hold accel data
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_accel_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_accel_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indices which hold analog data 
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_analog_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_analog_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get row indices which hold gyro data
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_gyro_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_gyro_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// get other channels for this board
        /// </summary>
        /// <param name="board_id"></param>
        /// <returns>array of row nums</returns>
        public static int[] get_other_channels (int board_id)
        {
            int[] len = new int[1];
            int[] channels = new int[512];
            int res = BoardControllerLibrary.get_other_channels (board_id, channels, len);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int[] result = new int[len[0]];
            for (int i = 0; i < len[0]; i++)
            {
                result[i] = channels[i];
            }
            return result;
        }

        /// <summary>
        /// set log level, logger is disabled by default
        /// </summary>
        /// <param name="log_level"></param>
        public static void set_log_level (int log_level)
        {
            int res = BoardControllerLibrary.set_log_level (log_level);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// enable BrainFlow's logger with level INFO
        /// </summary>
        public static void enable_board_logger ()
        {
            BoardControllerLibrary.set_log_level ((int)LogLevels.LEVEL_INFO);
        }

        /// <summary>
        /// disable BrainFlow's logger
        /// </summary>
        public static void disable_board_logger ()
        {
            BoardControllerLibrary.set_log_level ((int)LogLevels.LEVEL_OFF);
        }

        /// <summary>
        /// enable BrainFLow's logger with level TRACE
        /// </summary>
        public static void enable_dev_board_logger ()
        {
            BoardControllerLibrary.set_log_level ((int)LogLevels.LEVEL_TRACE);
        }

        /// <summary>
        /// redirect BrainFlow's logger from stderr to file
        /// </summary>
        /// <param name="log_file"></param>
        public static void set_log_file (string log_file)
        {
            int res = BoardControllerLibrary.set_log_file (log_file);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// send your own log message to BrainFlow's logger
        /// </summary>
        /// <param name="log_level"></param>
        /// <param name="message"></param>
        public static void log_message (int log_level, string message)
        {
            int res = BoardControllerLibrary.log_message (log_level, message);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// prepare BrainFlow's streaming session, allocate required resources
        /// </summary>
        public void prepare_session ()
        {
            int res = BoardControllerLibrary.prepare_session (board_id, input_json);
            if (res != (int) CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// send string to a board, use this method carefully and only if you understand what you are doing
        /// </summary>
        /// <param name="config"></param>
        public void config_board (string config)
        {
            int res = BoardControllerLibrary.config_board (config, board_id, input_json);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// start streaming thread, store data in internal ringbuffer
        /// </summary>
        /// <param name="buffer_size"></param>
        public void start_stream (int buffer_size = 3600 * 250)
        {
            int res = BoardControllerLibrary.start_stream (buffer_size, board_id, input_json);
            if (res != (int) CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// stop streaming thread, doesnt release other resources
        /// </summary>
        public void stop_stream ()
        {
            int res = BoardControllerLibrary.stop_stream (board_id, input_json);
            if (res != (int) CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// release BrainFlow's session
        /// </summary>
        public void release_session ()
        {
            int res = BoardControllerLibrary.release_session (board_id, input_json);
            if (res != (int) CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// get number of packages in ringbuffer
        /// </summary>
        /// <returns>number of packages</returns>
        public int get_board_data_count ()
        {
            int[] res = new int[1];
            int ec = BoardControllerLibrary.get_board_data_count (res, board_id, input_json);
            if (ec != (int) CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (ec);
            }
            return res[0];
        }

        /// <summary>
        /// get latest collected data, doesnt remove it from ringbuffer
        /// </summary>
        /// <param name="num_samples"></param>
        /// <returns>latest collected data, can be less than "num_samples"</returns>
        public double[,] get_current_board_data (int num_samples)
        {
            int num_rows = BoardShim.get_num_rows (board_id); 
            double[] data_arr = new double[num_samples * num_rows];
            int[] current_size = new int[1];
            int ec = BoardControllerLibrary.get_current_board_data (num_samples, data_arr, current_size, board_id, input_json);
		    if (ec != (int) CustomExitCodes.STATUS_OK) {
			    throw new BrainFlowException (ec);
            }
            double[,] result = new double[num_rows, current_size[0]];
            for (int i = 0; i < num_rows; i++)
            {
                for (int j = 0; j < current_size[0]; j++)
                {
                    result[i, j] = data_arr[i * current_size[0] + j];
                }
            }
            return result;
	    }

        /// <summary>
        /// get all collected data and remove it from ringbuffer
        /// </summary>
        /// <returns>all collected data</returns>
        public double[,] get_board_data ()
        {
		    int size = get_board_data_count ();
            int num_rows = BoardShim.get_num_rows (board_id);
            double[] data_arr = new double[size * num_rows];
            int ec = BoardControllerLibrary.get_board_data (size, data_arr, board_id, input_json);
		    if (ec != (int) CustomExitCodes.STATUS_OK) {
                throw new BrainFlowException (ec);
            }
            double[,] result = new double[num_rows, size];
            for (int i = 0; i < num_rows; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = data_arr[i * size + j];
                }
            }
            return result;
        }
    }
}
