
export interface ApiResponse<T> {
  data: T;
  isSuccess: boolean;
  messageTitle?: string;
  errorMessage?: string;
}