﻿using System;
using System.Numerics;

using Accord.Math;

namespace brainflow
{
    /// <summary>
    /// DataFilter class to perform signal processing
    /// </summary>
    public class DataFilter
    {
        // accord GetRow returns a copy instead pointer, so we can not easily update data in place like in other bindings

        /// <summary>
        /// perform lowpass filter, unlike other bindings instead in-place calculation it returns new array
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sampling_rate"></param>
        /// <param name="cutoff"></param>
        /// <param name="order"></param>
        /// <param name="filter_type"></param>
        /// <param name="ripple"></param>
        /// <returns>filtered data</returns>
        public static double[] perform_lowpass (double[] data, int sampling_rate, double cutoff, int order, int filter_type, double ripple)
        {
            double[] filtered_data = new double[data.Length];
            Array.Copy (data, filtered_data, data.Length);
            int res = DataHandlerLibrary.perform_lowpass (filtered_data, data.Length, sampling_rate, cutoff, order, filter_type, ripple);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return filtered_data;
        }

        /// <summary>
        /// perform highpass filter, unlike other bindings instead in-place calculation it returns new array
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sampling_rate"></param>
        /// <param name="cutoff"></param>
        /// <param name="order"></param>
        /// <param name="filter_type"></param>
        /// <param name="ripple"></param>
        /// <returns>filtered data</returns>
        public static double[] perform_highpass (double[] data, int sampling_rate, double cutoff, int order, int filter_type, double ripple)
        {
            double[] filtered_data = new double[data.Length];
            Array.Copy (data, filtered_data, data.Length);
            int res = DataHandlerLibrary.perform_highpass (filtered_data, data.Length, sampling_rate, cutoff, order, filter_type, ripple);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return filtered_data;
        }

        /// <summary>
        /// perform bandpass filter, unlike other bindings instead in-place calculation it returns new array
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sampling_rate"></param>
        /// <param name="center_freq"></param>
        /// <param name="band_width"></param>
        /// <param name="order"></param>
        /// <param name="filter_type"></param>
        /// <param name="ripple"></param>
        /// <returns>filtered data</returns>
        public static double[] perform_bandpass (double[] data, int sampling_rate, double center_freq, double band_width, int order, int filter_type, double ripple)
        {
            double[] filtered_data = new double[data.Length];
            Array.Copy (data, filtered_data, data.Length);
            int res = DataHandlerLibrary.perform_bandpass (filtered_data, data.Length, sampling_rate, center_freq, band_width, order, filter_type, ripple);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return filtered_data;
        }

        /// <summary>
        /// perform bandstop filter, unlike other bindings instead in-place calculation it returns new array
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sampling_rate"></param>
        /// <param name="center_freq"></param>
        /// <param name="band_width"></param>
        /// <param name="order"></param>
        /// <param name="filter_type"></param>
        /// <param name="ripple"></param>
        /// <returns>filtered data</returns>
        public static double[] perform_bandstop (double[] data, int sampling_rate, double center_freq, double band_width, int order, int filter_type, double ripple)
        {
            double[] filtered_data = new double[data.Length];
            Array.Copy (data, filtered_data, data.Length);
            int res = DataHandlerLibrary.perform_bandstop (filtered_data, data.Length, sampling_rate, center_freq, band_width, order, filter_type, ripple);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return filtered_data;
        }

        /// <summary>
        /// perform moving average or moving median filter, unlike other bindings instead in-place calculation it returns new array
        /// </summary>
        /// <param name="data"></param>
        /// <param name="period"></param>
        /// <param name="operation"></param>
        /// <returns>filered data</returns>
        public static double[] perform_rolling_filter (double[] data, int period, int operation)
        {
            double[] filtered_data = new double[data.Length];
            Array.Copy (data, filtered_data, data.Length);
            int res = DataHandlerLibrary.perform_rolling_filter (filtered_data, filtered_data.Length, period, operation);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return filtered_data;
        }

        /// <summary>
        /// perform data downsampling, it just aggregates data without applying lowpass filter
        /// </summary>
        /// <param name="data"></param>
        /// <param name="period"></param>
        /// <param name="operation"></param>
        /// <returns>data after downsampling</returns>
        public static double[] perform_downsampling (double[] data, int period, int operation)
        {
            if (period == 0)
            {
                throw new BrainFlowException ((int)CustomExitCodes.INVALID_ARGUMENTS_ERROR);
            }
            if (data.Length / period <= 0)
            {
                throw new BrainFlowException ((int)CustomExitCodes.INVALID_ARGUMENTS_ERROR);
            }
            double[] downsampled_data = new double[data.Length / period];
            int res = DataHandlerLibrary.perform_downsampling (data, data.Length, period, operation, downsampled_data);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return downsampled_data;
        }

        /// <summary>
        /// perform wavelet transform
        /// </summary>
        /// <param name="data">data for wavelet transform</param>
        /// <param name="wavelet">db1..db15,haar,sym2..sym10,coif1..coif5,bior1.1,bior1.3,bior1.5,bior2.2,bior2.4,bior2.6,bior2.8,bior3.1,bior3.3,bior3.5 ,bior3.7,bior3.9,bior4.4,bior5.5,bior6.8</param>
        /// <param name="decomposition_level">decomposition level</param>
        /// <returns>tuple of wavelet coeffs in format [A(J) D(J) D(J-1) ..... D(1)] where J is decomposition level, A - app coeffs, D - detailed coeffs, and array with lengths for each block</returns>
        public static Tuple<double[], int[]> perform_wavelet_transform (double[] data, string wavelet, int decomposition_level)
        {
            double[] wavelet_coeffs = new double[data.Length + 2 * (40 + 1)];
            int[] lengths = new int[decomposition_level + 1];
            int res = DataHandlerLibrary.perform_wavelet_transform (data, data.Length, wavelet, decomposition_level, wavelet_coeffs, lengths);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            int total_length = 0;
            foreach (int val in lengths)
            {
                total_length += val;
            }
            double[] truncated = new double[total_length];
            for (int i = 0; i < total_length; i++)
            {
                truncated[i] = wavelet_coeffs[i];
            }
            Tuple<double[], int[]> return_data = new Tuple<double[], int[]> (truncated, lengths);
            return return_data;
        }

        /// <summary>
        /// perform inverse wavelet transorm
        /// </summary>
        /// <param name="wavelet_data">tuple returned by perform_wavelet_transform</param>
        /// <param name="original_data_len">size of original data before direct wavelet transform</param>
        /// <param name="wavelet">db1..db15,haar,sym2..sym10,coif1..coif5,bior1.1,bior1.3,bior1.5,bior2.2,bior2.4,bior2.6,bior2.8,bior3.1,bior3.3,bior3.5 ,bior3.7,bior3.9,bior4.4,bior5.5,bior6.8</param>
        /// <param name="decomposition_level">level of decomposition</param>
        /// <returns>restored data</returns>
        public static double[] perform_inverse_wavelet_transform (Tuple<double[], int[]> wavelet_data, int original_data_len, string wavelet, int decomposition_level)
        {
            double[] original_data = new double[original_data_len];
            int res = DataHandlerLibrary.perform_inverse_wavelet_transform (wavelet_data.Item1, original_data_len, wavelet, decomposition_level,
                                                                            wavelet_data.Item2, original_data);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return original_data;
        }

        /// <summary>
        /// perform wavelet based denoising
        /// </summary>
        /// <param name="data">data for denoising</param>
        /// <param name="wavelet">db1..db15,haar,sym2..sym10,coif1..coif5,bior1.1,bior1.3,bior1.5,bior2.2,bior2.4,bior2.6,bior2.8,bior3.1,bior3.3,bior3.5 ,bior3.7,bior3.9,bior4.4,bior5.5,bior6.8</param>
        /// <param name="decomposition_level">level of decomposition in wavelet transform</param>
        /// <returns>denoised data</returns>
        public static double[] perform_wavelet_denoising (double[] data, string wavelet, int decomposition_level)
        {
            double[] filtered_data = new double[data.Length];
            Array.Copy (data, filtered_data, data.Length);
            int res = DataHandlerLibrary.perform_wavelet_denoising (filtered_data, filtered_data.Length, wavelet, decomposition_level);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return filtered_data;
        }

        /// <summary>
        /// perform direct fft
        /// </summary>
        /// <param name="data">data for fft</param>
        /// <param name="start_pos">start pos</param>
        /// <param name="end_pos">end pos, end_pos - start_pos must be a power of 2</param>
        /// <returns>complex array of size N / 2 + 1 of fft data</returns>
        public static Complex[] perform_fft(double[] data, int start_pos, int end_pos)
        {
            if ((start_pos < 0) || (end_pos > data.Length) || (start_pos >= end_pos))
            {
                throw new BrainFlowException ((int)CustomExitCodes.INVALID_ARGUMENTS_ERROR);
            }
            int len = end_pos - start_pos;
            if ((len & (len - 1)) != 0)
            {
                throw new BrainFlowException ((int)CustomExitCodes.INVALID_ARGUMENTS_ERROR);
            }
            double[] data_to_process = new double[len];
            Array.Copy (data, start_pos, data_to_process, 0, len);
            double[] temp_re = new double[len / 2 + 1];
            double[] temp_im = new double[len / 2 + 1];
            Complex[] output = new Complex[len / 2 + 1];

            int res = DataHandlerLibrary.perform_fft (data_to_process, len, temp_re, temp_im);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            for (int i = 0; i < len / 2 + 1; i++)
            {
                output[i] = new Complex (temp_re[i], temp_im[i]);
            }
            return output;
        }

        /// <summary>
        /// perform inverse fft
        /// </summary>
        /// <param name="data">data from perform_fft</param>
        /// <returns>restored data</returns>
        public static double[] perform_ifft(Complex[] data)
        {
            int len = (data.Length - 1) * 2;
            double[] temp_re = new double[data.Length];
            double[] temp_im = new double[data.Length];
            double[] output = new double[len];
            for (int i = 0; i < data.Length; i++)
            {
                temp_re[i] = data[i].Real;
                temp_im[i] = data[i].Imaginary;
            }
            int res = DataHandlerLibrary.perform_ifft (temp_re, temp_im, len, output);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            return output;
        }

        /// <summary>
        /// write data to csv file, data will be transposed
        /// </summary>
        /// <param name="data"></param>
        /// <param name="file_name"></param>
        /// <param name="file_mode"></param>
        public static void write_file (double[,] data, string file_name, string file_mode)
        {
            int num_rows = data.Rows();
            int res = DataHandlerLibrary.write_file (data.Flatten(), data.Rows (), data.Columns (), file_name, file_mode);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
        }

        /// <summary>
        /// read data from file, data will be transposed back to original format
        /// </summary>
        /// <param name="file_name"></param>
        /// <returns></returns>
        public static double[,] read_file (string file_name)
        {
            int[] num_elements = new int[1];
            int res = DataHandlerLibrary.get_num_elements_in_file (file_name, num_elements);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }
            double[] data_arr = new double[num_elements[0]];
            int[] num_rows = new int[1];
            int[] num_cols = new int[1];
            res = DataHandlerLibrary.read_file (data_arr, num_rows, num_cols, file_name, num_elements[0]);
            if (res != (int)CustomExitCodes.STATUS_OK)
            {
                throw new BrainFlowException (res);
            }

            double[,] result = new double[num_rows[0], num_cols[0]];
            for (int i = 0; i < num_rows[0]; i++)
            {
                for (int j = 0; j < num_cols[0]; j++)
                {
                    result[i, j] = data_arr[i * num_cols[0] + j];
                }
            }
            return result;
        }
    }
}
